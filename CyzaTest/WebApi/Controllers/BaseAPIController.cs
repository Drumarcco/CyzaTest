using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class BaseAPIController : ApiController
    {
        private ModelFactory _modelFactory;
        private ApplicationUserManager _appUserManager;
        protected ApplicationUserManager AppUserManager => _appUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();

        protected ModelFactory ModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory(this.Request, this.AppUserManager);
                }
                return _modelFactory;
            }
        }
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