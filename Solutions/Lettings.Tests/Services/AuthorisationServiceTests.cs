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


        private AuthorisationService _authorisationService;

        [SetUp]
        public void OneTimeSetup()
        {
            _agent1 = new Agent();
            _agent2 = new Agent();

            var office1 = new Office(_agent1);
            var office2 = new Office(_agent2);

            _adminUser = new User(null, UserType.admin);
            _managerUserAgent1 = new User(_agent1, UserType.manager);
            _employeeUserAgent1 = new User(_agent1, UserType.employee);
            _tenantUserAgent1 = new User(_agent1, UserType.tenant);

            _propertyAgent1 = new RentalProperty(office1);
            _propertyAgent2 = new RentalProperty(office2);

            _authorisationService = new AuthorisationService();
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
