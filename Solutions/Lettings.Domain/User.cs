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
        public virtual string PasswordSalt { get; set; }
        public virtual string Email { get; set; }
        public virtual string HomeNumber { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual Agent Agent { get; set; }
        public virtual DateTime Added { get; set; }
        public virtual User AddedBy { get; set; }

        public virtual string Postcode { get; set; }
        public virtual string HouseNumber { get; set; }
        public virtual string AddressLine1 { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string Town { get; set; }

        public User(Agent agent, UserType type)
        {
            Added = DateTime.Now;
            Agent = agent;
            UserType = type;
        }

        protected User()
        {

        }

        private  void SetAddress(string postcode, string addressLine1, string addressLine2, string houseNumber, string town)
        {
            Postcode = postcode; AddressLine1 = addressLine1;
            AddressLine2 = addressLine2; HouseNumber = houseNumber;
            Town = Town;
        }

    }
    public enum UserType
    {
        unknown = 0,
        employee = 1,
        manager = 2,
        tenant = 3,
        landlord = 4,
        admin = 5
    }
}
