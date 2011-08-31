using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class PropertyItem : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Room { get; set; }
    }
}
