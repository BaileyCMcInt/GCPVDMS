using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class ApplicationUser : IdentityUser
    { public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LocationPreference {get; set; }
        public string Availablity { get; set; }
        public string Interests { get; set; }
    }

}
