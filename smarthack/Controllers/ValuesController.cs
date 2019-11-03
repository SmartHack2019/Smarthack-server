using Microsoft.AspNetCore.Mvc;
using smarthack.Data;
using smarthack.Helper.AppNaiveBayes;
using smarthack.Helper.Classifier;
using System.Collections.Generic;

namespace smarthack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public static SmartHackDbContext _context;
        public ValuesController(SmartHackDbContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<IEnumerable<string>>> GetAsync()
        {
            //Classifier.Clasify();
            await MLExecuter.ExecuteAsync(_context);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
