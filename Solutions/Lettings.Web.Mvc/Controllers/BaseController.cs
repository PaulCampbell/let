using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lettings.Domain;
using Lettings.Web.Mvc.Helpers.Attributes;

namespace Lettings.Web.Mvc.Controllers
{
    [PostControllerFilter]
    public class BaseController : Controller
    {
        public void SetLoggedInUser(User user)
        {
            Session["LoggedInUser"] = user; 
        }


        // This is the user we are executing in the context of.
        // when impersonation is going on, this will be set to the impersonated user.
        // else wise, we will just return the above which gets set at log in...
        public User ExecutingUser
        {
            get {
                if (Session["ExecutingUser"] != null)
                {
                   return  (User)this.Session["ExecutingUser"];
                }
                return (User)this.Session["LoggedInUser"];
            }

            // this should only ever be set by the impersonation routine!
            set { Session["ExecutingUser"] = value; }
        }

        public bool IsImpersonatedSession()
        {
            if (Session["ExecutingUser"] == null)
            {
                return false;
            }

            return true;
        }

    }
}
