using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class ItemRegister : Entity
    {
        public virtual List<PropertyItem> Item { get; set; }
        public virtual DateTime DateTaken { get; set; }
        public virtual bool AgreedByTenant { get; set; }
        public virtual DateTime DateAgreedByTenant { get; set; }
    }
}
