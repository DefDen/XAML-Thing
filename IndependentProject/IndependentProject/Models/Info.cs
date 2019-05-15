using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndependentProject.Models
{
    class Info
    {
        
    }

    public class Main
    {
        public string e { get; set; }
    }

    public class Revisions
    {
        public string r { get; set; }
    }

    public class Warnings
    {
        public Main main { get; set; }
        public Revisions revisions { get; set; }
    }

    public class Normalized
    {
        public string from { get; set; }
        public string to { get; set; }
    }

    public class Revision
    {
        public string contentformat { get; set; }
        public string contentmodel { get; set; }
        public string h { get; set; }
    }

    public class __invalid_type__6032686
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public List<Revision> revisions { get; set; }
    }

    public class Pages
    {
        public __invalid_type__6032686 __invalid_name__6032686 { get; set; }
    }

    public class Query
    {
        public List<Normalized> normalized { get; set; }
        public Pages pages { get; set; }
    }

    public class InfoRootObject
    {
        public string batchcomplete { get; set; }
        public Warnings warnings { get; set; }
        public Query query { get; set; }
    }
}
