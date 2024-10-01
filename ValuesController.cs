using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiDemo.Controllers
{
    public class ValuesController : ApiController
    {

        static List<string> strlist = new List<string>() { "Hello", "World" };
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            string s = null;
            if (id == 1)
            {
                s = "Hello";
            }
            else if (id == 2)
            {
                s = "World";
            }
            else
            {
                s = null;
            }
            return s;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            strlist.Add(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            if (id == 1)
            {
                strlist[id] = value;
            }
            else
            {
                strlist[id] = value;
            }

        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            if (id != 0)
            {


                strlist.RemoveAt(id);

            }

        }
    }
}
