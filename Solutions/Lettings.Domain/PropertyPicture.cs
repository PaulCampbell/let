using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class PropertyPicture : Entity
    {
        public virtual string PictureUrl { get; set; }
        private virtual bool _preferredPicture;
        public virtual bool PreferredPicture { get { return _preferredPicture; } }
       
        internal virtual void SetPreferredPicture(bool preferred)
        {
            _preferredPicture = preferred;
        }
       

    }
}
