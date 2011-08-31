using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Lettings.Domain;

namespace Lettings.Tests
{
    [TestFixture]
    public class RentalPropertyTests
    {
        private RentalProperty _property;

        [TestFixtureSetUp]
        public void OneTimeSetUp()
        {
            var a = new Agent { Name = "TestAgent" };
            var o = new Office(a) { Name = "Head Office" };

            _property = new RentalProperty(o);

         
        }

        [Test]
        public void property_can_only_have_one_preferred_picture()
        {    // arrange
            var pic1 = new PropertyPicture { PictureUrl="pic1.png"};
            var pic2 = new PropertyPicture { PictureUrl="pic2.png"};
            var pic3 = new PropertyPicture { PictureUrl="pic3.png"};
             _property.Pictures.Add(pic1);
            _property.Pictures.Add(pic2);
            _property.Pictures.Add(pic3);
            _property.SetPreferredPicture(pic1);

            Assert.AreEqual(1, _property.Pictures.Count(p=>p.PreferredPicture == true));

            //act
            _property.SetPreferredPicture(pic2);

            // assert
            Assert.AreEqual(1, _property.Pictures.Count(p=>p.PreferredPicture == true));
        }
    }
}
