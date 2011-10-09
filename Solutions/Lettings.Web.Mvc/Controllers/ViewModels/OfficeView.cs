using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class OfficeView
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  string Postcode { get; set; }
        public  string HouseNumber { get; set; }
        public  string AddressLine1 { get; set; }
        public  string AddressLine2 { get; set; }
        public  string Town { get; set; }
    }
}