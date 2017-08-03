using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace pktexiservice.Controllers
{
    public class TemplateController : ApiController
    {
        // GET: api/Template
        public IHttpActionResult Get()
        {
            return Json("");
        }

        // GET: api/Template/5
        public IHttpActionResult Get(int id)
        {
            return Json("");
        }

        // POST: api/Template
        public IHttpActionResult Post([FromBody]string value)
        {
            return Json("");

        }

        // PUT: api/Template/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Json("");

        }

        // DELETE: api/Template/5
        public IHttpActionResult Delete(int id)
        {
            return Json("");

        }
    }
}
