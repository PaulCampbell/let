using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lettings.Web.Mvc.CastleWindsor;
using AutoMapper;

namespace Lettings.Tests
{
    [TestFixture]
    public class AutoMappingConfigurationTests
    {

        [Test]
        public void automapping_is_valid()
        {
            AutoMapperRegistry.ConfigureAutoMapper();
            Mapper.AssertConfigurationIsValid();
        }
    }
}
