using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class PropertyItem : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Room { get; set; }
    }
}
