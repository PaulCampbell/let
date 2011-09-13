namespace Lettings.Web.Mvc.Controllers
{
    using System.Web.Mvc;
    using Lettings.Web.Mvc.Controllers.ViewModels;
    using Lettings.Domain;
    using System.Web;
    using System.IO;
    using System;
    using Lettings.Domain.Services.Interfaces;
    using SharpArch.Domain.PersistenceSupport;
    using System.Web.Security;
    using Lettings.Domain.Contracts.Queries;

    public class HomeController : BaseController
    {
        IAuthenticationService _authenticationService;
        ILinqRepository<Agent> _agentRepository;
        ILinqRepository<User> _userRepository;

        public HomeController(IAuthenticationService authenticationService,
            ILinqRepository<Agent> agentRepository,
            ILinqRepository<User> userRepository)
        {
            _authenticationService = authenticationService;
            _agentRepository = agentRepository;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }


        [Transation]
        [HttpPost]
        public ActionResult Register(AddAgentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Ok, we have a valid Agent, Main office and first user
            //if there's a logo, upload it and grab the url...
            string savedFileName = "";
            foreach (string file in Request.Files)
            {
               var hpf = Request.Files[file] ;
               if (hpf.ContentLength == 0)
                  continue;
               
                savedFileName = Path.Combine(
                  AppDomain.CurrentDomain.BaseDirectory + "/images/agentLogos/", 
                  Path.GetFileName(hpf.FileName));
                  hpf.SaveAs(savedFileName);
            }

            var agent = new Agent { Name = model.Name, PictureUrl = savedFileName };
            agent.AddPhoneNumber(new PhoneNumber
            {
                Description = "Head office number",
                Name = "Head office number",
                Number = model.PhoneNumber
            }); 

            var office = new Office(agent)
            {
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                Postcode = model.Postcode,
                Name = model.OfficeName,
                HouseNumber = model.HouseNumber,
                Town = model.Town
            };

            // Check the email address has not already been used in the system...
            var emailAddressInUse = _userRepository.FindOne(new UserByEmailSpecification(model.EmailAddress));
            if (emailAddressInUse != null)
            {
                // this email address is already registered
                ModelState.AddModelError("EmailAddress", "This email address is already registered in the system.  Please choose a different email address for this agent account.");
                return View();
            }

            var mainUser = new User(agent, UserType.manager)
            {
                Email = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = _authenticationService.UpdatePassword(mainUser, model.Password);

            switch (result)
            {
                case Domain.Services.UpdatePasswordResult.notLongEnough:
                    ModelState.AddModelError("Password", "Password must be at least 5 charaters long");
                    return View();                

                case Domain.Services.UpdatePasswordResult.reservedWord:
                    ModelState.AddModelError("Password", "Password is too weak, please try another phrase");
                    return View();          

                case Domain.Services.UpdatePasswordResult.unknown:
                    throw new Exception("unknown password update error...");
            }
            
            // The password was succesful and their hash has been set.
            // save the new agent and the user and log them in...
            _agentRepository.Save(agent);
            _userRepository.Save(mainUser);

            var loginResult = _authenticationService.Login(model.EmailAddress, model.Password);
            // the log in result really should be successful - chuck exception if not
            if (loginResult != Domain.Services.LoginResult.successful)
            {
                throw new Exception("User registered successfully, but something went wrong authenticating them???");
            }
            
            FormsAuthentication.SetAuthCookie(model.EmailAddress, false);
            this.SetLoggedInUser(mainUser);

            return RedirectToAction("RedirectLoggedInUserOnwards", "Authentication");
        }

    }
}
