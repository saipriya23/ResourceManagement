using ResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResourceManagement.Controllers
{
    public class BookResourceController : ApiController
    {
        //for storing the booked resource in database
        [HttpPost]
        public IHttpActionResult BookResource(HistoryDetail BookingDetails)
        {
            if (ModelState.IsValid)
            {
                using (EmployeeEntities3 entity = new EmployeeEntities3())
                {
                    entity.HistoryDetails.Add(BookingDetails);
                    entity.SaveChanges();
                    return Ok(true);
                }
            }
            return Ok(false);
        }

        public HttpResponseMessage Options()
        {
            var res = new HttpResponseMessage();
            res.StatusCode = HttpStatusCode.OK;
            return res;
        }
    }
}

