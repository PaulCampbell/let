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

      
    }
}