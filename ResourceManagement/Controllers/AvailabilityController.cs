using ResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResourceManagement.Controllers
{
    public class AvailabilityController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Availability()
        {
            var entities = new EmployeeEntities3();
            var rec = entities.HistoryDetails.ToList();
            return Ok(rec);
        }

        //for checking the availability of the resource
        [HttpPost]
        public IHttpActionResult CheckAvailability(HistoryDetail userInfo)
        {

            if (ModelState.IsValid)
            {
                using (EmployeeEntities3 entity = new EmployeeEntities3())
                {

                    foreach (var book in entity.HistoryDetails)
                    {
                        if (userInfo.Resource_Id == book.Resource_Id)
                        {
                            if (userInfo.Start_Date > book.End_Date)
                            {
                                return Ok(true);
                            }
                            if (userInfo.Start_Date <= book.End_Date)
                            {
                                return Ok(false);
                            }
                        }
                        if (userInfo.Resource_Id != book.Resource_Id)
                        {
                            return Ok(true);
                        }
                    }

                    //var record=entity.HistoryDetails.Where(x => x.Resource_Id == (userInfo.Resource_Id) && x.Start_Date > (userInfo.End_Date));
                    //entity.HistoryDetails.Where(x => x.Resource_Id.Equals(userInfo.Resource_Id) && x.Start_Date > (userInfo.End_Date));
                    //var record = entity.HistoryDetails.Where(x => x.Start_Date>=(userInfo.Start_Date) && x.End_Date.Equals(userInfo.End_Date)).FirstOrDefault();
                    //if (record != null)
                    //{
                    //    return Ok(false);
                    //}

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
