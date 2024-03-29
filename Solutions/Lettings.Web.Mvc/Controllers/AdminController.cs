﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lettings.Web.Mvc.Helpers.Attributes;
using Lettings.Domain;
using SharpArch.Domain.PersistenceSupport;
using Lettings.Web.Mvc.Controllers.ViewModels;
using AutoMapper;
using Lettings.Domain.Contracts.Queries;

namespace Lettings.Web.Mvc.Controllers 
{
    // only admin users can go here!
    [LettingsAuthorisation(new UserType[] { UserType.admin })]
    public class AdminController : BaseController
    {
        private readonly ILinqRepository<RentalProperty> _propertyRepository;
        private readonly ILinqRepository<User> _userRepository;
        private readonly ILinqRepository<Agent> _agentRepository;

        public AdminController(ILinqRepository<RentalProperty> propertyRepository,
           ILinqRepository<User> userRepository, ILinqRepository<Agent> agentRepository)
        {
            _propertyRepository = propertyRepository;
            _userRepository = userRepository;
            _agentRepository = agentRepository;
        }

        [Transation]
        public ActionResult Index()
        {
            var model = new AdminIndexView();
            var agents = _agentRepository.FindAll().ToList();
            model.Agents = AutoMapper.Mapper.Map<List<Agent>, List<AgentSummaryView>>(agents);
            return View(model);
        }

        [HttpGet]
        public ActionResult AddAgent()
        {
            return View();
        }

        [HttpPost]
        [Transation]
        public ActionResult AddAgent(AddAgentModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

    
            // we're valid - map to domain model and persist.
           var agent = Mapper.Map<AddAgentModel, Agent>(model);
           _agentRepository.Save(agent);
            return RedirectToAction("Index");
        }

        public ActionResult ViewAgent(int id)
        {
            var agent = _agentRepository.FindOne(id);
            var userList = _userRepository.FindAll(new EmployeesOfAgentSpecification(id)).ToList();

            var model = AutoMapper.Mapper.Map<Agent, AgentFatView>(agent);
            model.Users = AutoMapper.Mapper.Map<List<User>, List<UserSummary>>(userList);

            return View(model);
        }

        public ActionResult Properties()
        {

            return View();
        }

        public ActionResult Impersonate(int userId)
        {
            var userToImpersonate = _userRepository.FindOne(userId);
            this.ExecutingUser = userToImpersonate;

            return RedirectToAction( "RedirectLoggedInUserOnwards", "Authentication");
        }

    }
}
