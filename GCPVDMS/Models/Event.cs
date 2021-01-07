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
        // [Display(Name = "Today's Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [CustomAdmissionDate(ErrorMessage = "Date must be greater than or equal to Today's Date.")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Please choose a start time")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Please choose an end time")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Please enter an event title")]
        public string EventTitle { get; set; }

        public string EventDescription { get; set; }

        public string POCName {get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string POCPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Not a valid email")]
        public string POCEmail { get; set; }

        public bool isEventActive { get; set; }

        [Required(ErrorMessage = "Please enter a number greater than 0")]
        public int NumVolunteersNeeded { get; set; }

        public int NumVolunteersSignedUp { get; set; }

        [Required(ErrorMessage = "Please choose a location")]
        [ForeignKey("LocationID")]
        public int LocationID { get; set; }

        public Location Location { get; set; }
    }
}
