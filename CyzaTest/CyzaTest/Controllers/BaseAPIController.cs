using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CyzaTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CyzaTest.Controllers
{
    public class BaseAPIController : ApiController
    {
        private ModelFactory _modelFactory;
        private ApplicationUserManager _appUserManager;

        protected ApplicationUserManager AppUserManager
            => _appUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

        protected ModelFactory ModelFactory => _modelFactory ?? (_modelFactory = new ModelFactory(Request, AppUserManager));

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (result.Succeeded) return null;
            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            if (ModelState.IsValid)
            {
                return BadRequest();
            }

            return BadRequest(ModelState);
        }
    }
}
