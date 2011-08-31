using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lettings.Domain;
using Lettings.Web.Mvc.Helpers.Attributes;

namespace Lettings.Web.Mvc.Controllers
{
    // this is for letting managers maintain their Agent's useraccounts etc.
    [LettingsAuthorisation(new UserType[] {  UserType.admin , UserType.manager })]
    public class AgentManagementController : Controller
    {
        
        //
        // GET: /AgentManagement/
        public ActionResult Index()
        {
            return View();
        }

    }
}
