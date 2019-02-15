using ResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResourceManagement.Controllers
{
    public class MobileListController : ApiController
    {
        //for getting the mobile list from database 
        [HttpGet]
        public IHttpActionResult Resourcelist()
        {
            var entities = new EmployeeEntities3();
            var rec = entities.Mobile_List.ToList();
            return Ok(rec);
        }
        public HttpResponseMessage Options()
        {
            var res = new HttpResponseMessage();
            res.StatusCode = HttpStatusCode.OK;
            return res;
        }
    }
}
