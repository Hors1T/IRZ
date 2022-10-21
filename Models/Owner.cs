using System;

namespace IRZ.Models
{
    public class Owner: BaseModel
    {
        public string display_name;
        public string title;
        public DateTime creation_date;
        public bool is_answered;
        public string link;
        
    }
}
