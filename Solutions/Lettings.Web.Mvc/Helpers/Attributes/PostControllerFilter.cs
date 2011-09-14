using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lettings.Domain;

namespace Lettings.Web.Mvc.Helpers.Attributes
{
    public class PostControllerFilter : ActionFilterAttribute
    {
        public  override void OnActionExecuted(ActionExecutedContext filterContext)
        {
              User executingUser;
              bool impersonatedSession = false;
              if (filterContext.HttpContext.Session["ExecutingUser"] != null)
                {
                   executingUser=  (User)filterContext.HttpContext.Session["ExecutingUser"];
                   impersonatedSession = true;
                }
              else
              {
                executingUser =  (User)filterContext.HttpContext.Session["LoggedInUser"];
              }

              filterContext.Controller.ViewBag.ExecutingUser = executingUser;
              filterContext.Controller.ViewBag.ImpersonatedSession = impersonatedSession ;
        }
    }
}