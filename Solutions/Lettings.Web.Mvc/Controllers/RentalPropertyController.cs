using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SharpArch.NHibernate.Web.Mvc;
using SharpArch.Domain.PersistenceSupport;
using Lettings.Domain;
using Lettings.Web.Mvc.Controllers.Queries;
using Lettings.Web.Mvc.Controllers.ViewModels;

namespace Lettings.Web.Mvc.Controllers
{
    public class RentalPropertyController : Controller
    {
        private readonly ILinqRepository<RentalProperty> _propertyRepository;
        private readonly ILinqRepository<User> _userRepository;


        public RentalPropertyController(ILinqRepository<RentalProperty> propertyRepository,
           ILinqRepository<User> userRepository)
        {
            _propertyRepository = propertyRepository;
            _userRepository = userRepository;
        }

        //
        // GET: /RentalProperty/
        [HttpGet]
        [Transaction]
        public ActionResult Index()
        {
            var userId = 1;
            var user = _userRepository.FindOne(userId);
            var properties = _propertyRepository.FindAll(new RentalPropertiesByAgentSpec(user.Agent)).ToList();
            RentalPropertiesView model = new RentalPropertiesView();
            model.Properties = AutoMapper.Mapper.Map<List<RentalProperty>, List<PropertySummaryView>>(properties);
            return View();
        }

    }
}
