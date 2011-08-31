using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lettings.Web.Mvc.Helpers.Attributes;
using Lettings.Domain;
using SharpArch.Domain.PersistenceSupport;

namespace Lettings.Web.Mvc.Controllers 
{
    // only admin users can go here!
    [LettingsAuthorisation(new List<UserType>{{UserType.admin}})]
    public class AdminController : BaseController
    {
        private readonly ILinqRepository<RentalProperty> _propertyRepository;
        private readonly ILinqRepository<User> _userRepository;


        public AdminController(ILinqRepository<RentalProperty> propertyRepository,
           ILinqRepository<User> userRepository)
        {
            _propertyRepository = propertyRepository;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {

            return View();
        }

        public ActionResult Agents()
        {

            return View();
        }

        public ActionResult Properties()
        {

            return View();
        }

        public ActionResult Impersonate(int userId)
        {
            var userToImpersonate = _userRepository.FindOne(userId);
            this.ExecutingUser = userToImpersonate;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult EndImpersonation()
        {
            // clear down the impersonation session...
            this.ExecutingUser = null;
            return RedirectToAction("Index");
        }

    }
}
