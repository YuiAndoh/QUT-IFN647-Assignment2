using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis; // for Analyser
using Lucene.Net.Documents; // for Document and Field
using Lucene.Net.Index; //for Index Writer
using Lucene.Net.Store; //for Directory
using Lucene.Net.Search; // for IndexSearcher
using Lucene.Net.QueryParsers;  // for QueryParser
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using Syn.WordNet;


namespace IR
{
    static class Program
    {
        public static List<string[]> items;
        public const string CONTENT_FN = "content";
        public const string QUERY_FN = "query";
        public const string QUERY_TYPE_FN = "query_type";
        public const string QUERY_ID_FN = "query_id";
        public const string URL_FN = "url";
        public const string PASSAGE_ID_FN = "passage_id";
        public const string IS_SELECTED_FN = "is_selected";
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;

        static Lucene.Net.Store.Directory luceneIndexDirectory;
        static Lucene.Net.Analysis.Analyzer analyzer;
        static Lucene.Net.Index.IndexWriter writer;
        public static Lucene.Net.Search.IndexSearcher searcher;
        static Lucene.Net.QueryParsers.QueryParser parser;
        //static Similarity customSimilarity;
        public static DateTime start;
        public static DateTime end;
        static string wordPath;
        //static WordNetEngine wordNet;

        static Program()
        {
            luceneIndexDirectory = null;
            analyzer = null;
            writer = null;
            //customSimilarity = new CustomSimilarity();
            items = new List<string[]>();
        }

        /// <summary>
        /// Flushes buffer and closes the index
        /// </summary>
        static public void CleanUpIndexer()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }

        /// <summary>
        /// Initialises the searcher object
        /// </summary>
        static public void CreateSearcher()
        {
            searcher = new IndexSearcher(luceneIndexDirectory);
            //searcher.Similarity = customSimilarity;
        }

        /// <summary>
        /// Initialises the parser object
        /// </summary>
        static public void CreateParser()
        {
            parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, CONTENT_FN, analyzer);
        }

        /// <summary>
        /// Closes the index after searching
        /// </summary>
        static public void CleanUpSearch()
        {
            searcher.Dispose();
        }

        static public List<SingleQuery> LoadJson(string filePath)
        {
            List<SingleQuery> collection;
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                collection = JsonConvert.DeserializeObject<List<SingleQuery>>(json);
            }
            return collection;
        }

        /// <summary>
        /// Creates the index at indexPath
        /// </summary>
        /// <param name="indexPath">Directory path to create the index</param>
        static public void CreateIndex(string indexPath)
        {
            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            analyzer = new Lucene.Net.Analysis.SimpleAnalyzer();
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);

            writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analyzer, true, mfl);
            //writer.SetSimilarity(customSimilarity);
        }


        static public double BuildIndex(string collectionPath, string indexPath)
        {
            CreateIndex(indexPath);
            CreateSearcher();
            CreateParser();


            List<SingleQuery> collection = LoadJson(collectionPath + "\\collection.json");

            start = System.DateTime.Now;
            foreach (SingleQuery item in collection)
            {
                for (int i = 0; i < item.passages.Count(); ++i)
                {
                    IndexPassage(item, i);
                }
            }
            end = System.DateTime.Now;

            CleanUpIndexer();

            return (end - start).TotalMilliseconds;
        }


        /// <summary>
        /// Indexes the given text
        /// </summary>
        /// <param name="text">Text to index</param>
        static public void IndexPassage(SingleQuery query, int passageIndex)
        {
            Lucene.Net.Documents.Document doc = new Document();
            doc.Add(new Field(QUERY_FN, query.query, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO));
            doc.Add(new Field(QUERY_TYPE_FN, query.query_type, Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS, Field.TermVector.NO));
            doc.Add(new Field(QUERY_ID_FN, query.query_id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS, Field.TermVector.NO));
            doc.Add(new Field(URL_FN, query.passages[passageIndex].url, Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS, Field.TermVector.NO));
            doc.Add(new Field(CONTENT_FN, query.passages[passageIndex].passage_text, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO));
            doc.Add(new Field(PASSAGE_ID_FN, query.passages[passageIndex].passage_ID.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS, Field.TermVector.NO));
            doc.Add(new Field(IS_SELECTED_FN, query.passages[passageIndex].is_selected.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED_NO_NORMS, Field.TermVector.NO));
            writer.AddDocument(doc);
        }


        /// <summary>
        /// Searches the index with the specified query text
        /// </summary>
        /// <param name="querytext">Text to search the index</param>
        /// <returns></returns>
        static public TopDocs SearchIndex(string querytext, out double time)
        {

            start = DateTime.Now;
            querytext = querytext.ToLower();
            char[] splitters = new char[] { '\t', '\'', '-', '(', ')', ',', '’', '\n', ':', ';', '?', '.', '!', '*' };
            foreach (var s in splitters)
            {
                querytext = querytext.Replace(s.ToString(), string.Empty);
            }
            try
            {
                Query query = parser.Parse(querytext);
                TopDocs results = searcher.Search(query, 100);
                end = DateTime.Now;
                time = (end - start).TotalMilliseconds;
                return results;
            }
            catch
            {
                string onlyLetters = new string(querytext.Where(char.IsLetter).ToArray());
                if (onlyLetters.Length == 0)
                {
                    onlyLetters = "asdfghjklzxcvbnmqwertyuiop";
                }
                Query query = parser.Parse(onlyLetters);
                TopDocs results = searcher.Search(query, 100);
                end = DateTime.Now;
                time = (end - start).TotalMilliseconds;
                return results;
            }
            //time = (end - start).TotalMilliseconds;
            //return;
        }

        static public int GetResults(TopDocs results)
        {
            int rank = 0;
            items.Clear();
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                rank++;
                // retrieve the document from the 'ScoreDoc' object
                Document doc = searcher.Doc(scoreDoc.Doc);
                string content = doc.Get(CONTENT_FN).ToString();
                string passage_id = doc.Get(PASSAGE_ID_FN).ToString();
                string query_id = doc.Get(QUERY_ID_FN).ToString();
                string is_selected = doc.Get(IS_SELECTED_FN).ToString();
                string url = doc.Get(URL_FN).ToString();
                items.Add(new[] { rank.ToString(), query_id, content, url, passage_id });
            }
            return results.TotalHits;
        }

        //static public void SaveResults(string fileName)
        //{
        //    FileStream stream = new FileStream(fileName, FileMode.Append);
        //    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
        //    {
        //        foreach (var item in items)
        //        {
        //            writer.WriteLine(item[1] + " Q0 " + item[4] + " " + item[0] + " " + "score " + "9600655_10320211_10153900_10285211_teamname");
        //        }
        //    }
        //}

        //static public List<string> LoadCompletedWord(string filePath)
        //{
        //    filePath = @"E:\QUT\Semester2\IFN647 Advanced Information Storage and Retrieval\Project\Custom IR System\IR System";
        //    wordPath = filePath;
        //    List<string> res = new List<string>();
        //    using (StreamReader r = new StreamReader(filePath + "\\google-10000-english-no-swears.txt"))
        //    {
        //        string word;

        //        while ((word = r.ReadLine()) != null)
        //        {
        //            res.Add(word);
        //        }
        //    }
        //    return res;
        //}

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetPathForm myGUI = new SetPathForm();
            Application.Run(myGUI);

            CleanUpSearch();
        }
    }
}