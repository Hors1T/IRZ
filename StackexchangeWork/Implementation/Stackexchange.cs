using IRZ.Models;
using IRZ.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace IRZ.StackexchangeWork
{
    public class Stackexchange:IStackexchage
    {
        private IRepository<Info> Info { get; set; }
        public async Task Work(DateTime fromdate, DateTime todate, string tagged)
        {
            HttpClient httpClient = new HttpClient();
            string request = "$\"https://api.stackexchange.com/2.3/search?fromdate={((DateTimeOffset)fromdate).ToUnixTimeSeconds()}&todate={((DateTimeOffset)todate).ToUnixTimeSeconds()}&order=desc&sort=activity&tagged={tagged}&site=stackoverflow\"";
            HttpResponseMessage response =
            (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
        /*    HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.stackexchange.com/2.3/search?fromdate={((DateTimeOffset)fromdate).ToUnixTimeSeconds()}&todate={((DateTimeOffset)todate).ToUnixTimeSeconds()}&order=desc&sort=activity&tagged={tagged}&site=stackoverflow");
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            var webResponse = request.GetResponse();
            var responseStream = webResponse.GetResponseStream();*/
            List<Item> items;
            JObject jObject = JObject.Parse(responseBody);
            JToken list = jObject["items"];
            items = list.ToObject<List<Item>>();
            foreach (var item in items)
            {
                Info.Create(new Info()
                {
                    Id = new Guid(),
                    creation_date = item.CreationDate,
                    link = item.Link,
                    display_name = item.Owner.DisplayName,
                    is_answered = item.IsAnswered,
                    title = item.Title
                }) ;
                 
            }
        }
    }
}
