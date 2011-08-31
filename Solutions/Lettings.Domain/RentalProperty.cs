using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class RentalProperty : Entity
    {
        public virtual string Postcode { get; set; }
        public virtual string HouseNumber { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string Town { get; set; }
        public virtual int NumberOfBedrooms { get; set; }
        public virtual bool PetsAllowed { get; set; }
        public virtual bool SmokersAllowed { get; set; }
        public virtual Office Office { get; set; }
        public virtual decimal AdvertisedPricePerMonth { get; set; }
        public virtual decimal AdvertisedBondAmount { get; set; }
        public virtual IList<PropertyPicture> Pictures { get; set; }
    
        public virtual Agent Agent
        { get
            {
                return Office.Agent;
            }
        }

        public  RentalProperty(Office office)
        {
            PetsAllowed = false;
            SmokersAllowed = false;
            Office = office;
            Pictures = new List<PropertyPicture>();
        }

        public virtual void SetPreferredPicture(PropertyPicture picture)
        {
            foreach (var p in Pictures)
            {
                p.SetPreferredPicture( false);
            }

            Pictures.Single(p => p == picture).SetPreferredPicture(true);
        }


    }
}
