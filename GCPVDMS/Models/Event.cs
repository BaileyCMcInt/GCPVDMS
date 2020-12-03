using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GCPVDMS.CustomValidation;

namespace GCPVDMS.Models
{
    public class Event
    {
        public int EventID { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please choose date.")]
        [Display(Name = "Today's Date")]
        [DataType(DataType.Date)]
        [CustomAdmissionDate(ErrorMessage = "Date must be greater than or equal to Today's Date.")]
        public DateTime EventDate { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public string EventTitle { get; set; }

        public string EventDescription { get; set; }

        public string POCName {get; set; }

        public string POCPhone { get; set; }

        public string POCEmail { get; set; }

        public bool isEventActive { get; set; }

        public int NumVolunteersNeeded { get; set; }

        public int NumVolunteersSignedUp { get; set; }

        [ForeignKey("LocationID")]
        public int LocationID { get; set; }
        public Location Location { get; set; }
    }
}
