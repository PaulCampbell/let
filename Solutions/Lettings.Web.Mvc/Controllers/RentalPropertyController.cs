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
using Lettings.Web.Mvc.Helpers.Attributes;

namespace Lettings.Web.Mvc.Controllers
{
    // This is for managing rental properties...
    [LettingsAuthorisation(new List<UserType>{{UserType.employee}, {UserType.manager}})]
    public class RentalPropertyController : BaseController
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
            var userId = this.ExecutingUser.Id;
            var user = _userRepository.FindOne(userId);

            // grab all of the properties from the Agent this user belongs to...
            var properties = _propertyRepository.FindAll(new RentalPropertiesByAgentSpec(user.Agent)).ToList();
            RentalPropertiesView model = new RentalPropertiesView();
            model.Properties = AutoMapper.Mapper.Map<List<RentalProperty>, List<PropertySummaryView>>(properties);
            return View();
        }

    }
}
