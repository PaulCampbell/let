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
 
        public bool UserCanManageAgent(Agent agent, User user)
        {
            if (user.UserType == UserType.admin)
            {
                return true;
            }

            if (user.UserType == UserType.manager)
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
            if (user.UserType == UserType.admin)
            {
                return true;
            }

            if (user.UserType == UserType.manager)
            {
                if (user.Agent == property.Agent)
                {
                    return true;
                }
            }

            if (user.UserType == UserType.employee)
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
