using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class AddAgentModel
    {
        [Required(ErrorMessage = "Name required")]
        public string Name { get; set; }
        public string PictureUrl { get; set; }
    }
}