using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GCPVDMS.CustomValidation;

namespace GCPVDMS.Models
{
    //[Table("Events")]
    public class Event
    {
        public int EventID { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [CustomEventDate(ErrorMessage = "Date must be greater than or equal to Today's Date.")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please choose a date.")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Please choose a start time")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Please choose an end time")]
        public DateTime EndTime { get; set; }

        [MaxLength(250)]
        [Required(ErrorMessage = "Please enter a title")]
        public string EventTitle { get; set; }

        public string EventDescription { get; set; }

        [MaxLength(250)]
        [Required(ErrorMessage = "Please enter a name")]
        public string POCName {get; set; }

        [MaxLength(50)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter a valid phone number")]
        [Required(ErrorMessage = "Please enter a phone number")]
        public string POCPhone { get; set; }

        [MaxLength(250)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", ErrorMessage = "Please enter a valid email")]
        [Required(ErrorMessage = "Please enter an email address")]
        public string POCEmail { get; set; }

        public bool isEventActive { get; set; }

        public bool IsArchived { get; set; }

        [Range(1,200, ErrorMessage = "Please enter a number between 1 and 200")]
        [Required(ErrorMessage = "Please enter a number greater than 0")]
        public int NumVolunteersNeeded { get; set; }

        public int NumVolunteersSignedUp { get; set; }

      //  [Required(ErrorMessage = "Please choose a location")]
        [ForeignKey("LocationID")]
        public int LocationID { get; set; }

        public Location Location { get; set; }

        public List<GCPEventTask> EventTasks { get; set; }
        public List<GCPEventDisclaimer> EventDisclaimers{ get; set; }
    }
}
