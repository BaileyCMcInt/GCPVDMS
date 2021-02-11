using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCPVDMS.Models;

namespace GCPVDMS.ViewModels
{
    //I did not use this class for displaying events the user is signed up for. 
    //This can be deleted if you wish.
    public class EventsImSignedUpFor
    {
        public IEnumerable<Event> EventID { get; set; }
        public IEnumerable<Location> Locations { get; set; }
        public IEnumerable<EventRegistration> EventRegistrations { get; set; }
    }
}
