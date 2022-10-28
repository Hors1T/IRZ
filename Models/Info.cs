using System;

namespace IRZ.Models
{
    public class Info: BaseModel
    {
        public string display_name { get; set; }
        public string title { get; set; }
        public long creation_date { get; set; }
        public bool is_answered { get; set; }
        public string link { get; set; }

    }
}
