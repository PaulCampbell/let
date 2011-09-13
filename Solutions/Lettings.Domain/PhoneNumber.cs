using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class PhoneNumber : Entity
    {
        public virtual string Number { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Agent Agent { get; set; }
    }
}
