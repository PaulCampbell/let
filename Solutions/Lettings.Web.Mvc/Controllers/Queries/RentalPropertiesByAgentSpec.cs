using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpArch.Domain.Specifications;
using Lettings.Domain;
using System.Linq.Expressions;

namespace Lettings.Web.Mvc.Controllers.Queries
{
    public class RentalPropertiesByAgentSpec: QuerySpecification<RentalProperty>
    {
        private readonly Agent agent;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalPropertiesByAgentSpec"/> class.
        /// </summary>
        /// <param name="agent">
        /// The agent
        /// </param>
        public RentalPropertiesByAgentSpec(Agent agent)
        {
            this.agent = agent;
        }

        public Agent Agent
        {
            get { return this.agent; }
        }

        public override Expression<Func<RentalProperty, bool>> MatchingCriteria
        {
            get { 
                
                return p => p.Agent == this.agent;
            
                }
        }
    }
}