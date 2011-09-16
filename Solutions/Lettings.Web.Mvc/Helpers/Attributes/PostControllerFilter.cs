using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lettings.Domain;
using Lettings.Web.Mvc.Controllers;
using System.Web.Security;

namespace Lettings.Web.Mvc.Helpers.Attributes
{
    public class PostControllerFilter : ActionFilterAttribute
    {
        public  override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.Controller as BaseController;
             
              filterContext.Controller.ViewBag.ExecutingUser = controller.ExecutingUser;
              filterContext.Controller.ViewBag.ImpersonatedSession = controller.IsImpersonatedSession() ;
        }

        public override  void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.Controller as BaseController;
            if (controller.ExecutingUser == null)
            {
                FormsAuthentication.SignOut();
            }
        }
    }
}