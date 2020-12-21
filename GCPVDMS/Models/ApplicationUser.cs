﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PreferredContact { get; set; }

        public string County { get; set; }

        public bool isVolunteer { get; set; }
        public bool isDonor { get; set; }

        public bool isApproved { get; set; }


    }

}
