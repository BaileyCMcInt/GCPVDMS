using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class VolunteerHour
    {
        public int UserHoursID { get; set; }
        public DateTime Date { get; set; }
        public decimal NumberOfHours { get; set; }

        [ForeignKey("Id")]
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("VolunteerGroupID")]
        public int VolunteeerGroupID { get; set; }
        public VolunteerGroup VolunteerGroup { get; set; }

        [ForeignKey("EventID")]
        public int EventID { get; set; }
        public Event Event { get; set; }

    }
}
