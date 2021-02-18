using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class EventRegistration
    {
        public int EventRegistrationID { get; set; }

        //[ForeignKey("Id")]
        //public int Id { get; set; }
        //public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("UserId")]
        
        public string UserId { get; set; } //added here for ef-code first approach, FK relationship
        //is seeded in the database. This was easiest approach to take to merge IdentityDbContext and
        //applicationDbContext

        [ForeignKey("EventID")]
        public int EventID { get; set; }
        public Event Event { get; set; }
        public bool isLogged { get; set; }
    }
}
