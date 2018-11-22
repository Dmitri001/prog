using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace prog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

		static List<Person> person_array = new List<Person>();

        // GET api/values
        [HttpGet]
		public ActionResult<IEnumerable<Person>> Get()
        {
			return person_array;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
            return person_array.First(p => p.id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]JObject value)
        {
			Person posted = value.ToObject<Person>();
			if (person_array.Where(p => ( p.id == posted.id || ( ( p.name == posted.name) && ( p.surname == posted.surname ) ) ) ).Count() == 0) //same id or same names are forbidden
				person_array.Add(posted);
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
