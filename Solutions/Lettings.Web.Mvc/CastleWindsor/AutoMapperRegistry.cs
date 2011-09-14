using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Lettings.Domain;
using Lettings.Web.Mvc.Controllers.ViewModels;

namespace Lettings.Web.Mvc.CastleWindsor
{
    public class AutoMapperRegistry
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<AddAgentModel, Agent>();
            Mapper.CreateMap<Agent, AgentSummaryView>();
            Mapper.CreateMap<Agent, AgentFatView>();
            Mapper.CreateMap<PhoneNumber, PhoneNumberView>();
            Mapper.CreateMap<Office, OfficeView>();
            Mapper.CreateMap<User, UserSummary>();
        }
    }
}