using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email required")]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "Password required")]
        public string Password { get; set; }

    }
}