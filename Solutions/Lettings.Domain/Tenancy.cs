using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class Tenancy : Entity
    {
        public virtual User User { get; set; }
        public virtual RentalProperty RentalProperty { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual decimal PricePerMonth { get; set; }
        public virtual decimal BondAmount { get; set; }
    }
}
