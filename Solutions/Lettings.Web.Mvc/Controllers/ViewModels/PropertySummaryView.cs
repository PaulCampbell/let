using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class PropertySummaryView
    {
        public string Postcode { get; set; }
        public string HouseNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Town { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public int NumberOfReceptionRooms { get; set; }
        public bool PetsAllowed { get; set; }
        public bool SmokersAllowed { get; set; }
        public OfficeView ManagingOffice { get; set; }
        public decimal AdvertisedPricePerMonth { get; set; }
        public decimal AdvertisedBondAmount { get; set; }
        public PropertyPicture Picture { get; set; }
        public bool Furnished { get; set; }
        public bool OnMarket { get; set; }
        public int ParkingSpaces { get; set; }

        public string Summary { get; set; }
    }
}