using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models.ViewModels
{
    public class CreateEventViewModel
    {
       
        public Event Event { get; set; }
        public List<Event> Events { get; set; } //testing, can delete if doesn't work :)

        public Location Location { get; set; }

        public List<Location> Locations { get; set; }
        
    }
}
