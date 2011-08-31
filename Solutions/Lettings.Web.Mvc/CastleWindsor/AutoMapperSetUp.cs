using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Lettings.Domain;
using Lettings.Web.Mvc.Controllers.ViewModels;

namespace Lettings.Web.Mvc.CastleWindsor
{
    public class AutoMapperSetUp
    {
        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Agent, AddAgentModel>();
        }
    }
}