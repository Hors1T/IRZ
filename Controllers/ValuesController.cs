using IRZ.Models;
using IRZ.Repositories;
using IRZ.StackexchangeWork;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IRZ.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IStackexchage Stackexchage { get; set; }
        private IRepository<Info> Infos { get; set; }

        public ValuesController(IStackexchage stackexchage, IRepository<Info> infos)
        {
            Stackexchage = stackexchage;
            Infos = infos;
        }
        // GET api/<ValuesController>/5
        [HttpGet, Route("get")]
        public string Get()
        {
            var information = new StringBuilder();
            var items = Infos.Get();
            foreach (var item in items)
            {
                information.Append($"<tr><td>{Stackexchage.ConvertData(item.creation_date)}</td><td>{item.title}</td>" +
                    $"<td>{item.display_name}</td><td>{item.is_answered}</td><td>{item.link}</td></tr>");
            }
            return information.ToString();
        }

        // POST api/<ValuesController>
        [HttpPost, Route("post")]
        public string Post([FromForm]Post post)
        {
            Stackexchage.Work(post);
            return "Request completed!!!";
            
        }
        // DELETE api/<ValuesController>/5
        [HttpDelete(), Route("Delete")]
        public void Delete()
        {
            Infos.Delete();
        }
    }
}
