using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class DatedPropertyNote : Entity
    {
        public virtual RentalProperty Property { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string Note { get; set; }
    }
}
