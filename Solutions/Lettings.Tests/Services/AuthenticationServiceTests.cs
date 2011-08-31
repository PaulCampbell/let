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
using Lettings.Domain.Contracts.Queries;

namespace Lettings.Tests.Services
{
    [TestFixture]
    public class AuthenticationServiceTests
    {
        private AuthenticationService _authService;
        private ILinqRepository<User> _userRepository;
        private IPasswordHashingService _passwordHashingService;

        [TestFixtureSetUp]
        public void EachTestSetUp()
        {
            _passwordHashingService = Substitute.For<IPasswordHashingService>();
            _passwordHashingService.ComputeHash("somestring", new byte[4]).ReturnsForAnyArgs("hashedPassword");
            _userRepository = Substitute.For<ILinqRepository<User>>();
            _authService = new AuthenticationService(_userRepository, _passwordHashingService);
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

        [Test]
        public void wrong_email_address_cannot_log_in()
        {
           var result = _authService.Login("invalidAddress", "SomePassword");

            Assert.AreEqual(LoginResult.unsuccessful, result);
        }

        [Test]
        public void wrong_password_cannot_log_in()
        { 
            var lookupSpec = new UserByEmailSpecication("someAddress");
            _userRepository.FindOne(lookupSpec).ReturnsForAnyArgs(new User());
            _passwordHashingService.VerifyHash("wrongpass", "SomeHash").ReturnsForAnyArgs(false);
        

            var result = _authService.Login("someAddress", "SomePassword");

            Assert.AreEqual(LoginResult.unsuccessful, result);
        }
    }
}
