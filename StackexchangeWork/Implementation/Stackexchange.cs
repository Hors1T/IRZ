using IRZ.Models;
using IRZ.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IRZ.StackexchangeWork
{
    public class Stackexchange : IStackexchage
    {
        private IRepository<Info> Infos { get; set; }

        public Stackexchange(IRepository<Info> infos)
        {
            Infos = infos;
        }
        public DateTime ConvertData(long unixTime)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTime).ToLocalTime();
            return dateTime;
        }
        

        public string GetUri(Post post)
        {
            var uri = new StringBuilder("https://api.stackexchange.com/2.3/search?");
            if (post.page == 0)
                uri.Append("page=&");
            else
                uri.Append($"page={post.page}&");
            if (post.pagesize == 0)
                uri.Append("page=&");
            else
                uri.Append($"pagesize={post.pagesize}&");
            if (post.fromdate == 0)
                uri.Append("fromdate=&");
            else
                uri.Append($"fromdate={post.fromdate}&");
            if (post.todate == 0)
                uri.Append("todate=&");
            else
                uri.Append($"todate={post.todate}&");
            if (String.IsNullOrEmpty(post.order))
                uri.Append("order=&");
            else
                uri.Append($"order={post.order}&");
            if (post.min==0||post.sort == "relevance")
                uri.Append("min=&");
            else
                uri.Append($"min={post.min}&");
            if (post.max == 0 || post.sort=="relevance")
                uri.Append("max=&");
            else
                uri.Append($"max={post.min}&");
            if (String.IsNullOrEmpty(post.sort))
                uri.Append("sort=&");
            else
                uri.Append($"sort={post.sort}&");
            if (String.IsNullOrEmpty(post.tagged))
                uri.Append("tagged=&");
            else
                uri.Append($"tagged={HttpUtility.UrlEncode(post.tagged)}&");
            if (String.IsNullOrEmpty(post.nottagged))
                uri.Append("nottagged=&");
            else
                uri.Append($"nottagged={HttpUtility.UrlEncode(post.nottagged)}&");
            if (String.IsNullOrEmpty(post.intitle))
                uri.Append("intitle=&");
            else
                uri.Append($"intitle={HttpUtility.UrlEncode(post.intitle)}&");
            uri.Append("site=stackoverflow");

            return uri.ToString();
        }
        public void Work(Post post)
        {

            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(GetUri(post));
            /*HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create($"https://api.stackexchange.com/2.3/search?fromdate={((DateTimeOffset)fromdate).ToUnixTimeSeconds()}&todate={((DateTimeOffset)todate).ToUnixTimeSeconds()}&order=desc&sort=activity&tagged={tagged}&site=stackoverflow");*/
            request1.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request1.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            var webResponse = request1.GetResponse();
            var responseStream = webResponse.GetResponseStream();
            string result;
            using (var reader = new StreamReader(responseStream))
            {
                 result = reader.ReadToEnd();
            }
            var items = JsonConvert.DeserializeObject<RootObject>(result);
            foreach (var item in items.items)
            {
                Infos.Create(new Info
                {
                    Id = new Guid(),
                    creation_date = item.creation_date,
                    link = item.link,
                    display_name = item.Owner.display_name,
                    is_answered = item.is_answered,
                    title = item.title
                });

            }
        }
    }
}
