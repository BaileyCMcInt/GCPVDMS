using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models.ViewModels
{
    public class LogMyHoursViewModel
    {
        public VolunteerHour VolunteerHour { get; set; }//volunteerhour object (entity)
        public List<VolunteerHour> VolunteerHours { get; set; } //list of volunteerhour objects
        public Location Location { get; set; } //location object
        public List<Event> Events { get; set; } //list of event objects
        public Event Event { get; set; } //event object
        public string UserId { get; set; } //this is how we store the userID FK, added to code to 
        //utilize code-first approach but the relationship is seeded in the datbase.
        public string nonEventInfo { get; set; }

        public ApplicationUser User { get; set; } //user object
        public EventRegistration EventRegistration { get; set; }
        public List<EventRegistration> EventRegistrations { get; set; }
    }
}
