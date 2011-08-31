using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class AdminIndexView
    {
        public List<AgentSummaryView> Agents { get; set; }
    }
}