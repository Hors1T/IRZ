using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IRZ.Models
{
    public class Item
    {
        [JsonPropertyName("tags")]
        public List<string> tags { get; set; }

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }

        [JsonPropertyName("is_answered")]
        public bool is_answered { get; set; }

        [JsonPropertyName("view_count")]
        public int view_count { get; set; }

        [JsonPropertyName("answer_count")]
        public int answer_count { get; set; }

        [JsonPropertyName("score")]
        public int score { get; set; }

        [JsonPropertyName("last_activity_date")]
        public long last_activity_date { get; set; }

        [JsonPropertyName("creation_date")]
        public long creation_date { get; set; }

        [JsonPropertyName("last_edit_date")]
        public long last_edit_date { get; set; }

        [JsonPropertyName("question_id")]
        public int question_id { get; set; }

        [JsonPropertyName("content_license")]
        public string content_license { get; set; }

        [JsonPropertyName("link")]
        public string link { get; set; }

        [JsonPropertyName("title")]
        public string title { get; set; }

        [JsonPropertyName("accepted_answer_id")]
        public int accepted_answer_id { get; set; }

        [JsonPropertyName("closed_date")]
        public long closed_date { get; set; }

        [JsonPropertyName("closed_reason")]
        public string closed_reason { get; set; }
    }
}
