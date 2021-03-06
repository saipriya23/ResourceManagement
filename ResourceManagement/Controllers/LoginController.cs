﻿using ResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ResourceManagement.Controllers
{

    public class LoginController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Login()
        {
            return Ok();
        }

        //for validating the login details
        [HttpPost]
        public IHttpActionResult Login( LoginDetail userInfo)
        {
            if (ModelState.IsValid)
            {
                using (EmployeeEntities3 entity = new EmployeeEntities3())
                {
                    var record = entity.LoginDetails.Where(x => x.UserName.Equals(userInfo.UserName) && x.Password.Equals(userInfo.Password)).FirstOrDefault();
                    if (record != null)
                    {

                        return Ok(true);
                    }
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
