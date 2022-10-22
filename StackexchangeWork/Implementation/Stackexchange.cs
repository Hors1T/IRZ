using IRZ.Models;
using IRZ.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace IRZ.StackexchangeWork
{
    public class Stackexchange:IStackexchage
    {
        private IRepository<Owner> Owner { get; set; }
        public void Work(DateTime fromdate, DateTime todate, string tagged)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.stackexchange.com/2.3/search?fromdate={fromdate}&todate={todate}&order=desc&sort=activity&tagged={tagged}&site=stackoverflow");
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            var webResponse = request.GetResponse();
            var responseStream = webResponse.GetResponseStream();
            List<Owner> items;
            using (StreamReader reader = new StreamReader(responseStream))
            {
                string json = reader.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Owner>>(json);
            }
            foreach (var item in items)
                Owner.Create(item);
            
        }
    }
}
