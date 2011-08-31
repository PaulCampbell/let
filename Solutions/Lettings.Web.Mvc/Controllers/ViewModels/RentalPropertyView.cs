using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class RentalPropertyView
    {

        public  LandlordView Landlord { get; set; }
      
        public  string Postcode { get; set; }
        public  string HouseNumber { get; set; }
        public  string AddressLine1 { get; set; }
        public  string AddressLine2 { get; set; }
        public  string Town { get; set; }
        public  int NumberOfBedrooms { get; set; }
        public  int NumberOfBathrooms { get; set; }
        public  int NumberOfReceptionRooms { get; set; }
        public  bool PetsAllowed { get; set; }
        public  bool SmokersAllowed { get; set; }
        public  OfficeView ManagingOffice { get; set; }
        public  decimal AdvertisedPricePerMonth { get; set; }
        public  decimal AdvertisedBondAmount { get; set; }
        public  IList<PropertyPicture> Pictures { get; set; }
        public  bool Furnished { get; set; }
        public  bool OnMarket { get; set; }
        public  int ParkingSpaces { get; set; }

        public  string Summary { get; set; }

        public  string DetailDescription { get; set; }

        public  string NotableFeatures { get; set; }

        public  string GeneralNotes { get; set; }

        public  IList<DatedPropertyNoteView> DatedNotes { get; set; }
    }
}