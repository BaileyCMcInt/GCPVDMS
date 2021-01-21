using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class EventRegistration
    {
        public int registrationID { get; set; }

        [ForeignKey("Id")]
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("EventID")]
        public int EventID { get; set; }
        public Event Event { get; set; }
    }
}
