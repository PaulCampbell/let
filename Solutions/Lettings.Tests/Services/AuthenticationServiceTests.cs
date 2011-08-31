using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lettings.Domain.Services;
using SharpArch.Domain.PersistenceSupport;
using Lettings.Domain;
using Lettings.Domain.Services.Interfaces;
using NSubstitute;

namespace Lettings.Tests.Services
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private AuthenticationService _authService;
        private ILinqRepository<User> _userRepository;
        private IPasswordHashingService _passwordHashingService;

        [SetUp]
        public void OneTimeSetUp()
        {
            _authService = new AuthenticationService(_userRepository, _passwordHashingService);
            _passwordHashingService = Substitute.For<IPasswordHashingService>();
            _passwordHashingService.ComputeHash("somestring", new byte[4]).ReturnsForAnyArgs("hashedPassword");


        }

        [Test]
        public void password_minimum_five_charaters()
        {
            var newPassword = "four";
            var result = _authService.UpdatePassword(new User(), newPassword);

            Assert.AreEqual(UpdatePasswordResult.notLongEnough, result);
        }

        [Test]
        public void valid_password_can_be_updated()
        {
            var newPassword = "aNewValidPassword";
            var result = _authService.UpdatePassword(new User(), newPassword);

            Assert.AreEqual(UpdatePasswordResult.successful, result);
        }
    }
}
