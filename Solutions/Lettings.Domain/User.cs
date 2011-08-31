using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class User : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual string HashedPassword { get; set; }
        public virtual string Email { get; set; }
        public virtual Agent Agent { get; set; }

    }
}
