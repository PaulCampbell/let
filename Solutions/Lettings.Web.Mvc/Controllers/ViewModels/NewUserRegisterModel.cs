using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class NewUserRegisterModel
    {
        [Required(ErrorMessage = "First name required")]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required")]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Must be at least 5 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Passwords must match")]
        [Compare("Password", ErrorMessage = "Passwords must match")]   
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Agency name required")]
        [DisplayName("Agency name")]
        public string Name { get; set; }

        [DisplayName("Agency logo")]
        public string PictureUrl { get; set; }
    }
}