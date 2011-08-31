using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class Office : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Postcode { get; set; }
        public virtual string HouseNumber { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string Town { get; set; }
        public virtual Agent Agent { get; set; }

        public Office(Agent agent)
        {
            Agent = agent;
        }
    }
}
