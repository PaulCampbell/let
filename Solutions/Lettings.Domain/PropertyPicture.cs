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
        private  bool _preferredPicture;
        public virtual bool PreferredPicture { get { return _preferredPicture; } }
        public virtual PictureType PictureType { get; set; }
       
        public virtual void SetPreferredPicture(bool preferred)
        {
            _preferredPicture = preferred;
        }

        public PropertyPicture()
        {
            PictureType = PictureType.normal;
        }

    }

    public enum PictureType
    {
        normal = 0,
        floorplan = 1,
        energyrating = 2
    }
}
