using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IRZ.Models
{
    public class Item
    {
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("owner")]
        public Owner Owner { get; set; }

        [JsonPropertyName("is_answered")]
        public bool IsAnswered { get; set; }

        [JsonPropertyName("view_count")]
        public int ViewCount { get; set; }

        [JsonPropertyName("answer_count")]
        public int AnswerCount { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("last_activity_date")]
        public int LastActivityDate { get; set; }

        [JsonPropertyName("creation_date")]
        public long CreationDate { get; set; }

        [JsonPropertyName("last_edit_date")]
        public long LastEditDate { get; set; }

        [JsonPropertyName("question_id")]
        public int QuestionId { get; set; }

        [JsonPropertyName("content_license")]
        public string ContentLicense { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("accepted_answer_id")]
        public int AcceptedAnswerId { get; set; }

        [JsonPropertyName("closed_date")]
        public long ClosedDate { get; set; }

        [JsonPropertyName("closed_reason")]
        public string ClosedReason { get; set; }
    }
}
