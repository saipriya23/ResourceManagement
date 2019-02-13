using ResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResourceManagement.Controllers
{
    public class LaptopListController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ResourceList()
        {
            var entities = new EmployeeEntities();
            var records = entities.Laptop_List.ToList();
            return Ok(records);
        }
        public HttpResponseMessage Options()
        {
            var res = new HttpResponseMessage();
            res.StatusCode = HttpStatusCode.OK;
            return res;
        }
    }
}
