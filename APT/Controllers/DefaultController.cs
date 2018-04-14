using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APT.Controllers
{
    public class DefaultController : ApiController
    {
        // GET: api/Default
        public IEnumerable<string> Get()
        {
            FlatData[] elements = new FlatData[]
            {
             new FlatData {Id = 1, Text = "A"  },
               new FlatData {Id = 2, Text = "B"},
               new FlatData {Id = 3, ParentId = 1, Text = "C"},
               new FlatData {Id = 4, ParentId = 1, Text = "D"},
               new FlatData {Id = 5, ParentId = 2, Text = "E"}
            };

            IEnumerable<NodeData> nodes = elements.RecursiveJoin(element => element.Id,
               element => element.ParentId,
               (FlatData element, IEnumerable<NodeData> children) => new NodeData()
               {
                   Text = element.Text,
                   Children = children
               });
            var t = nodes.ToList();
            var p = JsonConvert.SerializeObject(t);
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
