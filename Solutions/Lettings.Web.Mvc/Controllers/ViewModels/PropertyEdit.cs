using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class PropertyEdit
    {
        [Required]
        public string Postcode { get; set; }

        [Required]
        [DisplayName("House number")]
        public string HouseNumber { get; set; }

        [Required]
        [DisplayName("Address line 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Address line 2")]
        public string AddressLine2 { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        [DisplayName("Number of bedrooms")]
        public int NumberOfBedrooms { get; set; }
        public List<SelectListItem> NumberOfBedroomsOptions { get; set; }

        [Required]
        [DisplayName("Number of bathrooms")]
        public int NumberOfBathrooms { get; set; }
        public List<SelectListItem> NumberOfBathroomsOptions { get; set; }

        [Required]
        [DisplayName("Number of reception rooms")]
        public int NumberOfReceptionRooms { get; set; }
        public List<SelectListItem> NumberOfReceptionRoomsOptions { get; set; }

        [DisplayName("Pets allowed")]
        public bool PetsAllowed { get; set; }

        [DisplayName("Smokers allowed")]
        public bool SmokersAllowed { get; set; }

        [DisplayName("Price per month")]
        public decimal? AdvertisedPricePerMonth { get; set; }

        [DisplayName("Bond")]
        public decimal? AdvertisedBondAmount { get; set; }

        public bool Furnished { get; set; }

        public int? ParkingSpaces { get; set; }
        [DisplayName("Number of parking spaces")]
        public List<SelectListItem> ParkingSpacesOptions { get; set; }

        public string Summary { get; set; }

        [DisplayName("Detailed description")]
        public string DetailDescription { get; set; }

        [DisplayName("Notable features")]
        public string NotableFeatures { get; set; }

        [DisplayName("Property type")]
        public PropertyType PropertyType { get; set; }
        public List<SelectListItem> PropertyTypeDropDownOptions { get; set; }

        [DisplayName("Property status")]
        public PropertyStatus PropertyStatus { get; set; }
        public List<SelectListItem> PropertyStatusDropDownOptions { get; set; }

        public PropertyEdit()
        {
            PropertyStatus = PropertyStatus.OffMarketUntenanted;
            PropertyType = PropertyType.Unknown;



            // drop down values...
            PropertyTypeDropDownOptions = new List<SelectListItem>();
            PropertyTypeDropDownOptions.Add(new SelectListItem() { Text = "Please select", Value = "0" });
            var propertyTypeValues = (int[])System.Enum.GetValues(typeof(PropertyType));
            var propertyTypeNames = System.Enum.GetNames(typeof(PropertyType));

            for (int i = 0; i <= propertyTypeNames.Length - 1; i++)
            {
                var item = new SelectListItem();
                item.Text = propertyTypeNames[i];
                item.Value = propertyTypeValues[i].ToString();
                PropertyTypeDropDownOptions.Add(item);  
            }

            PropertyStatusDropDownOptions = new List<SelectListItem>();
            var propertyStatusValues = (int[])System.Enum.GetValues(typeof(PropertyStatus));
            var propertyStatusNames = System.Enum.GetNames(typeof(PropertyStatus));

            for (int i = 0; i <= propertyStatusNames.Length - 1; i++)
            {
                var item = new SelectListItem();
                item.Text = propertyStatusNames[i];
                item.Value = propertyStatusValues[i].ToString();
                PropertyTypeDropDownOptions.Add(item);
            }

            NumberOfBedroomsOptions = new List<SelectListItem>();
            NumberOfBedroomsOptions.Add(new SelectListItem() { Text = "Please select", Value = "-1" });
            for (int i = 1; i <= 10; i++)
            {
                NumberOfBedroomsOptions.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            NumberOfBathroomsOptions = new List<SelectListItem>();
            NumberOfBathroomsOptions.Add(new SelectListItem() { Text = "Please select", Value = "-1" });
            for (int i = 1; i <= 5; i++)
            {
                NumberOfBathroomsOptions.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            NumberOfReceptionRoomsOptions = new List<SelectListItem>();
            NumberOfReceptionRoomsOptions.Add(new SelectListItem() { Text = "Please select", Value = "-1" });
            for (int i = 1; i <= 5; i++)
            {
                NumberOfReceptionRoomsOptions.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }

            ParkingSpacesOptions = new List<SelectListItem>();
            ParkingSpacesOptions.Add(new SelectListItem() { Text = "Please select", Value = "-1" });
            for (int i = 0; i <= 5; i++)
            {
                ParkingSpacesOptions.Add(new SelectListItem { Value = i.ToString(), Text = i.ToString() });
            }
        }

    }
}