namespace Lettings.Domain
{
    using SharpArch.Domain.DomainModel;
    using System.Collections.Generic;

    public class Agent : Entity
    {
        public virtual string Name { get; set; }
        public virtual string PictureUrl { get; set; }
        public virtual  IList<PhoneNumber> PhoneNumbers { get; set; }
        public virtual IList<Office> Offices { get; set; }

        public Agent()
        {
            PhoneNumbers = new List<PhoneNumber>();
            Offices = new List<Office>();
        }
    }
}