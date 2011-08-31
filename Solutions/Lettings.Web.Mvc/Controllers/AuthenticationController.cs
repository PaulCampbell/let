using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lettings.Web.Mvc.Controllers.ViewModels;
using SharpArch.NHibernate.Web.Mvc;
using Lettings.Domain.Services.Interfaces;
using Lettings.Domain;
using SharpArch.Domain.PersistenceSupport;
using Lettings.Domain.Contracts.Queries;
using System.Web.Security;

namespace Lettings.Web.Mvc.Controllers
{
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILinqRepository<User> _userRepository;

        public AuthenticationController(IAuthenticationService authenticationService, ILinqRepository<User> userRepository)
        {
            _authenticationService = authenticationService;
            _userRepository = userRepository;

        }
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
            if (!ModelState.IsValid)
            {
                return View();
            }

            var u = _userRepository.FindOne(new UserByEmailSpecication(model.EmailAddress));
            var result = _authenticationService.Login(model.EmailAddress, model.Password);

            if(result != Domain.Services.LoginResult.successful)
            {
                ModelState.AddModelError("Login unsuccessful", "Email or password incorrect");
                return View();   
            }

            // login was successful...
            FormsAuthentication.SetAuthCookie(model.EmailAddress, model.PersistentLogin);
            this.SetLoggedInUser(u);
            return RedirectToAction("RedirectLoggedInUserOnwards");  
        }

        private ActionResult RedirectLoggedInUserOnwards()
        {
            switch (this.ExecutingUser.UserType)
            {
                case  UserType.admin :
                    RedirectToAction("Index", "Admin");
                    break;

                case UserType.landlord :
                    RedirectToAction("");
                    break;

                default:
                    // we're not dealing with anyone else here...
                    FormsAuthentication.SignOut();
                    break;
            }
            return View("Index", "Home");
        }

    }
}
