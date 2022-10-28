using System.Text.Json.Serialization;

namespace IRZ.Models
{
    public class Owner
    {
        [JsonPropertyName("account_id")]
        public int account_id { get; set; }

        [JsonPropertyName("reputation")]
        public int reputation { get; set; }

        [JsonPropertyName("user_id")]
        public int user_id { get; set; }

        [JsonPropertyName("user_type")]
        public string user_type { get; set; }

        [JsonPropertyName("accept_rate")]
        public int accept_rate { get; set; }

        [JsonPropertyName("profile_image")]
        public string profile_image { get; set; }

        [JsonPropertyName("display_name")]
        public string display_name { get; set; }

        [JsonPropertyName("link")]
        public string link { get; set; }
    }
}
