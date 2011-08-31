using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lettings.Domain;
using Lettings.Domain.Services;
using SharpArch.Domain.PersistenceSupport;
using NSubstitute;

namespace Lettings.Tests.Services
{
    [TestFixture]
    public class AuthorisationServiceTests
    {
        private User _adminUser;
        private User _managerUserAgent1;
        private User _employeeUserAgent1;
        private User _tenantUserAgent1;

        private Agent _agent1;
        private Agent _agent2;

        private RentalProperty _propertyAgent1;
        private RentalProperty _propertyAgent2;

        private UserType _manager;
        private UserType _employee;
        private UserType _tenant;
        private UserType _admin;
        private UserType _landlord;

        private AuthorisationService _authorisationService;

        [SetUp]
        public void OneTimeSetup()
        {
            _agent1 = new Agent();
            _agent2 = new Agent();

            var office1 = new Office(_agent1);
            var office2 = new Office(_agent2);

            _manager = new UserType { Name = "Manager" };
            _employee = new UserType { Name = "Employee" };
            _tenant = new UserType { Name = "Tenant" };
            _admin = new UserType { Name = "Admin" };
            _landlord = new UserType { Name = "Landlord" };


            _adminUser = new User { UserType = _admin };
            _managerUserAgent1 = new User { UserType = _manager, Agent = _agent1 };
            _employeeUserAgent1 = new User { UserType = _employee, Agent = _agent1 };
            _tenantUserAgent1 = new User { UserType = _tenant, Agent = _agent1 };

            _propertyAgent1 = new RentalProperty(office1);
            _propertyAgent2 = new RentalProperty(office2);

            var userTypeRepo = Substitute.For<ILinqRepository<UserType>>();
            var userTypes = new List<UserType> { { _landlord } , { _admin }, { _manager }, { _employee }, { _tenant } };
           
            userTypeRepo.FindAll().Returns(userTypes.AsQueryable());

            _authorisationService = new AuthorisationService(userTypeRepo);
        }


        [Test]
        public void tenant_cannot_manage_any_property()
        {
            var result = _authorisationService.UserCanManageRentalProperty(_propertyAgent2, _tenantUserAgent1);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void employee_can_manage_property_in_their_agency()
        {
            var result = _authorisationService.UserCanManageRentalProperty(_propertyAgent1, _employeeUserAgent1);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void employee_can_not_manage_property_in_other_agency()
        {
            var result = _authorisationService.UserCanManageRentalProperty(_propertyAgent2, _employeeUserAgent1);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void manager_can_manage_property_in_their_agency()
        {
            var result = _authorisationService.UserCanManageRentalProperty(_propertyAgent1, _managerUserAgent1);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void manager_can_not_manage_property_in_other_agency()
        {
            var result = _authorisationService.UserCanManageRentalProperty(_propertyAgent2, _managerUserAgent1);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void admin_can_manage_any_property()
        {
            var result = _authorisationService.UserCanManageRentalProperty(_propertyAgent2, _adminUser);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void manager_can_manage_their_own_agency()
        {
            var result = _authorisationService.UserCanManageAgent(_agent1, _managerUserAgent1);
            Assert.AreEqual(true, result);
        }

        [Test]
        public void manager_can_not_manage_other_agency()
        {
            var result = _authorisationService.UserCanManageAgent(_agent2, _managerUserAgent1);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void employee_can_not_manage_any_agency()
        {
            var result = _authorisationService.UserCanManageAgent(_agent1, _employeeUserAgent1);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void tenant_can_not_manage_any_agency()
        {
            var result = _authorisationService.UserCanManageAgent(_agent1, _tenantUserAgent1);
            Assert.AreEqual(false, result);
        }

    }
}
