using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.PersistenceSupport;
using Lettings.Domain.Contracts.Queries;
using Lettings.Domain.Services.Interfaces;
using System.Security.Cryptography;

namespace Lettings.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILinqRepository<User> _userRepository;
        private readonly IPasswordHashingService _passwordHashingService;

        public AuthenticationService(ILinqRepository<User> userRepository, IPasswordHashingService passwordHashingService)
        {
            _passwordHashingService = passwordHashingService;
            _userRepository = userRepository;
        }

        public LoginResult Login(string email, string password)
        {
            var u = _userRepository.FindOne(new UserByEmailSpecication(email));
            if (u == null)
            {
                return LoginResult.unsuccessful;
            }

            if (!_passwordHashingService.VerifyHash( password, u.HashedPassword))
            {
                return LoginResult.unsuccessful;
            }

            return LoginResult.successful;
        }

        public UpdatePasswordResult UpdatePassword(User user, string newPassword)
        {
            if (newPassword.Length < 5)
            {
                return UpdatePasswordResult.notLongEnough;
            }

            var salt = GenerateSalt();

            var newHash = _passwordHashingService.ComputeHash(newPassword, salt);

            user.HashedPassword = newHash;

            return UpdatePasswordResult.successful;

        }

        private byte[] GenerateSalt()
        {
            byte[] saltBytes;
            // Define min and max salt sizes.
            int minSaltSize = 4;
            int maxSaltSize = 8;

            // Generate a random number for the size of the salt.
            Random random = new Random();
            int saltSize = random.Next(minSaltSize, maxSaltSize);

            // Allocate a byte array, which will hold the salt.
            saltBytes = new byte[saltSize];

            // Initialize a random number generator.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            // Fill the salt with cryptographically strong byte values.
            rng.GetNonZeroBytes(saltBytes);

            return saltBytes;
        }
    }

    public enum LoginResult
    {
        unknown = 0,
        successful = 1,
        unsuccessful = 2
    }

    public enum UpdatePasswordResult
    {
        unknown = 0,
        successful = 1,
        notLongEnough = 2,
        reservedWord = 3
    }
}
