using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class ItemRegister : Entity
    {
        public List<PropertyItem> Item { get; set; }
        public DateTime DateTaken { get; set; }
        public bool AgreedByTenant { get; set; }
        public DateTime DateAgreedByTenant { get; set; }
    }
}
