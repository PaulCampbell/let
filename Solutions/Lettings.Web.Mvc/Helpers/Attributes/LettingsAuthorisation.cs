using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lettings.Domain;

namespace Lettings.Web.Mvc.Helpers.Attributes
{
    public class LettingsAuthorisation : AuthorizeAttribute
    {
        UserType[] _userTypes;

        public LettingsAuthorisation(UserType[] userTypes)
        {
            _userTypes = userTypes;
        }

        // we check the usertype of the executing user (impersonated user during impersonation)
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (User)httpContext.Session["ExecutingUser"];
            if (user == null)
            {
                user = (User)httpContext.Session["LoggedInUser"];
            }

            if (!_userTypes.Any(ut=>ut==user.UserType))
                return false;

            return base.AuthorizeCore(httpContext);
        }
    }
}