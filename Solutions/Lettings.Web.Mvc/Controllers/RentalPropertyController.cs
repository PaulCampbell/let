using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpArch.NHibernate.Web.Mvc;
using SharpArch.Domain.PersistenceSupport;
using Lettings.Domain;
using Lettings.Web.Mvc.Controllers.Queries;

namespace Lettings.Web.Mvc.Controllers
{
    public class RentalPropertyController : Controller
    {
        private readonly ILinqRepository<RentalProperty> _propertyRepository;
        private readonly ILinqRepository<User> _userRepository;
      
        //
        // GET: /RentalProperty/
        [HttpGet]
        [Transaction]
        public ActionResult Index()
        {
            var userId = 1;
            var user = _userRepository.FindOne(userId);
            var properties = _propertyRepository.FindAll(new RentalPropertiesByAgentSpec(user.Agent));


            return View();
        }

    }
}
