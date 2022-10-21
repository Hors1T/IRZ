using IRZ.Models;
using IRZ.Repositories;
using IRZ.StackexchangeWork;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IRZ.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IStackexchage Stackexchage { get; set; }
        private IRepository<Owner> Owners { get; set; }

        public ValuesController(IStackexchage stackexchage, IRepository<Owner> owners)
        {
            Stackexchage = stackexchage;
            Owners = owners;
        }
        // GET api/<ValuesController>/5
        [HttpGet, Route("get")]
        public string Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.stackexchange.com/2.3/search?fromdate=1666224000&todate=1664928000&order=desc&sort=activity&tagged=python&site=stackoverflow");
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            var response = "";

            using (var webResponse = request.GetResponse())
            using (var sr = new StreamReader(webResponse.GetResponseStream()))
            {
                response = sr.ReadToEnd();
            }

            return response;
        }

        // POST api/<ValuesController>
        [HttpGet,Route("post")]
        public void Post(/*DateTime fromdate, DateTime todate, string tagged*/ )
        {
            var fromdate = "2000-10-11";
            var todate = "2022-10-13";
            var tagged = "python";
            Stackexchage.Work(fromdate,todate,tagged);
            
        }
        [HttpPost, Route("post1")]
        public string post1(/*DateTime fromdate, DateTime todate, string tagged*/ )
        {
           return "str";

        }
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
