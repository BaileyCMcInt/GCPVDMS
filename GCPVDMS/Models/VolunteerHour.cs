using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class VolunteerHour
    {
        //maps all volunteerhour table attributes with code-first approach
        public int VolunteerHourID { get; set; }
        
        public DateTime Date { get; set; } //date of volunteer hour request
        [Required]
        public DateTime volunteerHourDate { get; set; }
        public double NumberOfHours { get; set; }

        public string UserId { get; set; } //FK relationship to IdentityDBContext is seeded in the database

    
        //[ForeignKey("VolunteerGroupID")]
        //public int VolunteerGroupID { get; set; }
        public VolunteerGroup VolunteerGroup { get; set; }
        [ForeignKey("EventID")]
        public int EventID { get; set; }
        public Event Event { get; set; }
        public bool isApproved { get; set; }
        public bool isDenied { get; set; }
        public string volunteerDescription { get; set; }

        [Required(ErrorMessage = "Must enter a time")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Must enter a time")]
        public DateTime EndTime { get; set; }
    }
}
