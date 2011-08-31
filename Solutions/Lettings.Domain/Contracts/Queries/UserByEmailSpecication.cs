using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.Specifications;
using System.Linq.Expressions;

namespace Lettings.Domain.Contracts.Queries
{
    public class UserByEmailSpecication : QuerySpecification<User>
    {
        private readonly string email;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileByUserNameSpecification"/> class.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        public UserByEmailSpecication(string email)
        {
            this.email = email;
        }

        public string Email
        {
            get { return this.email; }
        }

        public override Expression<Func<User, bool>> MatchingCriteria
        {
            get { return u => u.Email == this.email; }
        }
    }
}
