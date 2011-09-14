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
      
        [Transaction]
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var u = _userRepository.FindOne(new UserByEmailSpecification(model.EmailAddress));
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

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home"); ;
        }

        public ActionResult RedirectLoggedInUserOnwards()
        {
            switch (this.ExecutingUser.UserType)
            {
                case  UserType.admin :
                    return RedirectToAction("Index", "Admin");

                case UserType.employee :
                    return RedirectToAction("Index", "AgentManagement");

                case UserType.manager:
                    return RedirectToAction("Index", "AgentManagement");

                default:
                    // we're not dealing with anyone else here...
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Logout");
            }    
        }

        public ActionResult EndImpersonation()
        {
            // clear down the impersonation session...
            this.ExecutingUser = null;
            return RedirectToAction("RedirectLoggedInUserOnwards", "Authentication");
        }

    }
}
