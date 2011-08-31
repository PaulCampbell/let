using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lettings.Web.Mvc.Controllers.ViewModels;
using SharpArch.NHibernate.Web.Mvc;

namespace Lettings.Web.Mvc.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [Transaction]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {


            return RedirectToAction("Index", "Home");
        }

    }
}
