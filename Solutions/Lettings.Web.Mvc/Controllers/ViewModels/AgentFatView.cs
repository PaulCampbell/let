﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lettings.Web.Mvc.Controllers.ViewModels
{
    public class AgentFatView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public virtual IList<PhoneNumberView> PhoneNumbers { get; set; }
        public IList<OfficeView> Offices { get; set; }
        public IList<UserSummary> Users { get; set; }

        public AgentFatView()
        {

        }

    }
}