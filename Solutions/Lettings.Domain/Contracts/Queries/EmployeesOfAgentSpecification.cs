using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.Specifications;
using System.Linq.Expressions;

namespace Lettings.Domain.Contracts.Queries
{
    public class EmployeesOfAgentSpecification : QuerySpecification<User>
    {
        private readonly int agentId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileByUserNameSpecification"/> class.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        public EmployeesOfAgentSpecification(int agentId)
        {
            this.agentId = agentId;
        }

        public int AgentId
        {
            get { return this.agentId; }
        }

        public override Expression<Func<User, bool>> MatchingCriteria
        {
            get { return u => u.Agent.Id == this.agentId && (u.UserType == UserType.employee || u.UserType == UserType.manager); }
        }
    }
}
