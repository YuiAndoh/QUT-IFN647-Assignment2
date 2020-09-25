using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR
{
    public class Passage
    {
        public int is_selected { get; set; }
        public string url { get; set; }
        public string passage_text { get; set; }
        public int passage_ID { get; set; }
    }

    public class SingleQuery
    {
        public IList<Passage> passages { get; set; }
        public int query_id { get; set; }
        public IList<string> answers { get; set; }
        public string query_type { get; set; }
        public string query { get; set; }
    }
}
