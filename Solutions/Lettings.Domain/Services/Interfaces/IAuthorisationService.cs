using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lettings.Domain.Services.Interfaces
{
    public interface IAuthorisationService
    {
         bool UserCanManageAgent(Agent agent, User user);
         bool UserCanManageRentalProperty(RentalProperty property, User user);
    }
}
