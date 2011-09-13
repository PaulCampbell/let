using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class AddAgentModel
    {
        [Required]
        [DisplayName("Your email address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "First name required")]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        [DisplayName("Last name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Password required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Must be at least 5 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwords must match")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Agency name required")]
        [DisplayName("Agency name")]
        public string Name { get; set; }

        [DisplayName("Agency logo")]
        public string PictureUrl { get; set; }
       
        [DisplayName("Main phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Office name")]
        [Required(ErrorMessage="Office name required")]
        public string OfficeName { get; set; }

        [Required]
        [DisplayName("Office postcode")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "Building number / name required")]
        [DisplayName("Building number / name")]
        public string HouseNumber { get; set; }

        [Required]
        [DisplayName("Office address line 1")]
        public string AddressLine1 { get; set; }

        [DisplayName("Office address line 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Office town required")]
        [DisplayName("Office town")]
        public string Town { get; set; }

    }
}