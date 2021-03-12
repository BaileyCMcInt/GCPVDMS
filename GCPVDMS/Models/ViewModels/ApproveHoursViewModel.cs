using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models.ViewModels
{
    public class ApproveHoursViewModel
    {
        public ApplicationUser User { get; set; }
        public VolunteerHour VolunteerHour { get; set; }
        public List<VolunteerHour> VolunteerHours { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public List<Location> Locations { get; set; }
        public Event Event { get; set; }
    }
}
