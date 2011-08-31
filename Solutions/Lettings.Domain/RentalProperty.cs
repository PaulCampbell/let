using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class RentalProperty : Entity
    {
        private User _landlord;
        public virtual User Landlord { get { return _landlord; } }
        public bool SetLandlord(User landlord)
        {
            if (_landlord.UserType == UserType.landlord)
            {
                _landlord = landlord;
                return true;
            }
            return false;
        }
        public virtual string Postcode { get; set; }
        public virtual string HouseNumber { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string Town { get; set; }
        public virtual int NumberOfBedrooms { get; set; }
        public virtual int NumberOfBathrooms { get; set; }
        public virtual int NumberOfReceptionRooms { get; set; }
        public virtual bool PetsAllowed { get; set; }
        public virtual bool SmokersAllowed { get; set; }
        public virtual Office ManagingOffice { get; set; }
        public virtual decimal AdvertisedPricePerMonth { get; set; }
        public virtual decimal AdvertisedBondAmount { get; set; }
        public virtual IList<PropertyPicture> Pictures { get; set; }
        public virtual bool Furnished { get; set; }
        public virtual bool OnMarket { get; set; }
        public virtual int ParkingSpaces { get; set; }

        public virtual string Summary { get; set; }

        // markdown or similar?
        public virtual string DetailDescription { get; set; }

        public virtual string NotableFeatures { get; set; }

        // markdown or similar?
        public virtual string GeneralNotes { get; set; }

        public virtual IList<DatedPropertyNote> DatedNotes { get; set; }
       
        public virtual DateTime Added { get; set; }
        public virtual User AddedBy { get; set; }

        public virtual Agent Agent
        { 
            get{ return ManagingOffice.Agent; }
        }

        public  RentalProperty(Office office)
        {
            PetsAllowed = false;
            SmokersAllowed = false;
            ManagingOffice = office;
            Pictures = new List<PropertyPicture>();
        }

        public virtual void SetPreferredPicture(PropertyPicture picture)
        {
            foreach (var p in Pictures)
            {
                p.SetPreferredPicture(false);
            }

            Pictures.Single(p => p == picture).SetPreferredPicture(true);
        }


    }
}
