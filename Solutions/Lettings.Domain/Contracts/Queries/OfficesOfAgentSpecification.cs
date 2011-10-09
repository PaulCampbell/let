using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.Specifications;
using System.Linq.Expressions;

namespace Lettings.Domain.Contracts.Queries
{
    public class OfficesOfAgentSpecification : QuerySpecification<Office>
    {
        private readonly int agentId;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileByUserNameSpecification"/> class.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        public OfficesOfAgentSpecification(int agentId)
        {
            this.agentId = agentId;
        }

        public int AgentId
        {
            get { return this.agentId; }
        }

        public override Expression<Func<Office, bool>> MatchingCriteria
        {
            get { return o => o.Agent.Id == this.agentId ; }
        }
    }
}
