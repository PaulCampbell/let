﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Domain.DomainModel;

namespace Lettings.Domain
{
    public class UserType : Entity
    {
        public virtual string Name { get; set; }
    }
}