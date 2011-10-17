using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lettings.Domain;
using Lettings.Web.Mvc.Helpers.Attributes;
using SharpArch.Domain.PersistenceSupport;
using Lettings.Web.Mvc.Controllers.ViewModels;
using Lettings.Domain.Contracts.Queries;

namespace Lettings.Web.Mvc.Controllers
{
    // this is for letting managers maintain their Agent's useraccounts etc.
    [LettingsAuthorisation(new UserType[] {   UserType.manager, UserType.employee })]
    public class AgentManagementController : BaseController
    {
        ILinqRepository<Agent> _agentRepository;
        ILinqRepository<User> _userRepository;
        ILinqRepository<Office> _officeRepository;
        ILinqRepository<RentalProperty> _propertyRepository;

        public AgentManagementController(ILinqRepository<Agent> agentRepository,
             ILinqRepository<User> userRepository, ILinqRepository<Office> officeRepository,
            ILinqRepository<RentalProperty> propertyRepository)
        {
            _agentRepository = agentRepository;
            _userRepository = userRepository;
            _officeRepository = officeRepository;
            _propertyRepository = propertyRepository;
        }
        
        [HttpGet]
        [Transation]
        public ActionResult Index()
        {
            var agentID = this.ExecutingUser.Agent.Id;

            var agent = _agentRepository.FindOne(agentID);
            var userList = _userRepository.FindAll(new EmployeesOfAgentSpecification(agentID)).ToList();

            var model = AutoMapper.Mapper.Map<Agent, AgentFatView>(agent);
            model.Users = AutoMapper.Mapper.Map<List<User>, List<UserSummary>>(userList);

            return View(model);
        }

        [HttpGet]
        [Transation]
        public ActionResult Properties()
        {
            return View();
        }

        [HttpGet]
        [Transation]
        public ActionResult Landlords()
        {
            return View();
        }

        [HttpGet]
        [Transation]
        public ActionResult Tenants()
        {
            return View();
        }

        [HttpGet]
        [Transation]
        public ActionResult AddProperty()
        {
            var offices = _officeRepository.FindAll(new OfficesOfAgentSpecification(this.ExecutingUser.Agent.Id));
            var officeOptions = new List<SelectListItem>();
            
            foreach (var o in offices)
            {
                officeOptions.Add(new SelectListItem { Value = o.Id.ToString(), Text = o.Name });
            }
          
            return View();
        }

        [HttpPost]
        [Transation]
        public ActionResult AddProperty(PropertyEdit property)
        {
            if(!ModelState.IsValid)
            {
                return View(property);
            }

            // we're valid... add the property
            var p = AutoMapper.Mapper.Map<PropertyEdit, RentalProperty>(property);
            var office = _officeRepository.FindOne(property.OfficeId);

            _propertyRepository.Save(p);
            return View();
        }

        [HttpGet]
        [Transation]
        public PartialViewResult PropertiesGrid()
        {

            return PartialView();
        }


        [HttpGet]
        [Transation]
        public ActionResult Account()
        {
            var agentID = this.ExecutingUser.Agent.Id;

            var agent = _agentRepository.FindOne(agentID);
            var userList = _userRepository.FindAll(new EmployeesOfAgentSpecification(agentID)).ToList();

            var model = AutoMapper.Mapper.Map<Agent, AgentFatView>(agent);
            model.Users = AutoMapper.Mapper.Map<List<User>, List<UserSummary>>(userList);

            return View(model);
        }

    }
}
