using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class AddAgentModel
    {
   

        [Required(ErrorMessage = "Name required")]
        [DisplayName("Agency name")]
        public string Name { get; set; }

        [DisplayName("Agency logo")]
        public string PictureUrl { get; set; }
    }
}