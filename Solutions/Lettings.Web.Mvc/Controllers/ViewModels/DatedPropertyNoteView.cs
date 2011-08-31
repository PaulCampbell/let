using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class DatedPropertyNoteView
    {
        public virtual DateTime Created { get; set; }
        public virtual string Note { get; set; }
    }
}