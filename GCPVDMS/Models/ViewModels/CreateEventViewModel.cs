using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models.ViewModels
{
    public class CreateEventViewModel
    {

        public Event Event { get; set; }
        public List<Event> Events { get; set; }

        public Location Location { get; set; }

        public List<Location> Locations { get; set; }

        public List<GCPTask> GCPTasks { get; set; }

        public GCPTask GCPTask { get; set; }

        public GCPEventTask GCPEventTask { get; set; }  
        public List<GCPEventTask> GCPEventTasks { get; set; }
        public EventRegistration EventRegistration { get; set; }
        public List<EventRegistration> EventRegistrations { get; set; }
        public ApplicationUser User { get; set; }
        public List<ApplicationUser> Users { get; set; }

        public string UserId { get; set; }


    }
}
