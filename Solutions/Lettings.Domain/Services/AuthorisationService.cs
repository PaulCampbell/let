using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lettings.Domain.Services.Interfaces;
using SharpArch.Domain.PersistenceSupport;

namespace Lettings.Domain.Services
{
    public class AuthorisationService : IAuthorisationService
    {
        private ILinqRepository<UserType> _userTypeRepository;

        public AuthorisationService(ILinqRepository<UserType> userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }

        public bool UserCanManageAgent(Agent agent, User user)
        {
            var userTypes = _userTypeRepository.FindAll();
            if (user.UserType == userTypes.First<UserType>(ut => ut.Name == "Admin"))
            {
                return true;
            }

            if (user.UserType == userTypes.First<UserType>(ut => ut.Name == "Manager"))
            {
                if (user.Agent == agent)
                {
                    return true;
                }
            }

            return false;
        }

        public bool UserCanManageRentalProperty(RentalProperty property, User user)
        {
            var userTypes = _userTypeRepository.FindAll().ToList();
            if (user.UserType == userTypes.First<UserType>(ut => ut.Name == "Admin"))
            {
                return true;
            }

            if (user.UserType == userTypes.First<UserType>(ut => ut.Name == "Manager"))
            {
                if (user.Agent == property.Agent)
                {
                    return true;
                }
            }

            if (user.UserType == userTypes.First<UserType>(ut => ut.Name == "Employee"))
            {
                if (user.Agent == property.Agent)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
