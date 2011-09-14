using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class RentalPropertiesView
    {
        public List<PropertySummaryView> Properties { get; set; }
        public int ResultsPerPage { get; set; }
        public int PageNumber { get; set; }
        public int TotalResult { get; set; }
    }
}