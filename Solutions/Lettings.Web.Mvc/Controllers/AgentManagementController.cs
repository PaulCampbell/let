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
    [LettingsAuthorisation(new UserType[] {  UserType.admin , UserType.manager, UserType.employee })]
    public class AgentManagementController : BaseController
    {
        ILinqRepository<Agent> _agentRepository;
        ILinqRepository<User> _userRepository;

        public AgentManagementController(ILinqRepository<Agent> agentRepository,
             ILinqRepository<User> userRepository)
        {
            _agentRepository = agentRepository;
            _userRepository = userRepository;
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
        public PartialViewResult PropertiesGrid()
        {

            return PartialView();
        }

    }
}
