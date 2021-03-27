using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PreferredContact { get; set; }
        public string SecondPreferredContact { get; set; }

        public string County { get; set; }

        public bool isVolunteer { get; set; }
        public bool isDonor { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime Birthday { get; set; }

        public byte[] ProfilePicture { get; set; }

        public bool FirstTimeLogin { get; set; }

        public string VolunteerType { get; set; }

    }

}
