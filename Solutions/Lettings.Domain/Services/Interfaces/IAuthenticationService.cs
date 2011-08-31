using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.PersistenceSupport;

namespace Lettings.Domain.Services.Interfaces
{
    public interface IAuthenticationService
    {
         LoginResult Login(string email, string password);
         UpdatePasswordResult UpdatePassword(User user, string newPassword);

    }
}
