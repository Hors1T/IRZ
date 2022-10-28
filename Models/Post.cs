using System;

namespace IRZ.Models
{
    public class Post
    {
        public long fromdate { get; set; }
        public long todate { get; set; }
        public string tagged { get; set; }
        public string nottagged { get; set; }
        public string intitle { get; set; }
        public string order { get; set; }
        public int page { get; set; }
        public int pagesize { get; set; }
        public string sort { get; set; }
        public long min { get; set; }
        public long max { get; set; }

    }
}
