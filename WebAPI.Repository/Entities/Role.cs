﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Repository.Entities
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}