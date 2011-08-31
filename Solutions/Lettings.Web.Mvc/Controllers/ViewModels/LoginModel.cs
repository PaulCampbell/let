using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class LoginModel
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email required")]
        public string EmailAddress { get; set; }
        
        [Required(ErrorMessage = "Password required")]
       
        public string Password { get; set; }

         [DisplayName("Remember me on this computer")]
        public bool PersistentLogin { get; set; }

    }
}