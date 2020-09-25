using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IR
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            //AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            //searchText.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //List<string> words = Program.LoadCompletedWord(SetPathForm.wordsPath);
            //foreach (string word in words)
            //{
            //    source.Add(word);
            //}
            //searchText.AutoCompleteCustomSource = source;
            //searchText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            listView1.FullRowSelect = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            int hits;
            double time;
            string queryText = searchText.Text;

            listView1.Items.Clear();

            if (preProcessCheckBox.Checked == true)
            {
                queryText = "\"" + queryText + "\"";
            }

            hits = Program.GetResults(Program.SearchIndex(queryText, out time));
            searchTimeLabel.Text = "search time: " + time.ToString() + " ms";
            totalHitsLabel.Text = "total hits: " + hits.ToString();

            foreach (var item in Program.items)
            {
                listView1.Items.Add(new ListViewItem(new [] { item[0].ToString(), item[1], item[2], item[3] }));
            }
        }

        private void saveResultButton_Click(object sender, EventArgs e)
        {
            //using (SaveFileDialog dialog = new SaveFileDialog())
            //{
            //    dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //    dialog.FilterIndex = 2;
            //    dialog.RestoreDirectory = true;

            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        Program.SaveResults(dialog.FileName.ToString());
            //    }
            //}
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;
            MessageBox.Show(listView1.SelectedItems[0].SubItems[2].Text, "Content of " + listView1.SelectedItems[0].SubItems[1]);

        }

    }
}
