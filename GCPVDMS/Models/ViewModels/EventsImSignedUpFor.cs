using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCPVDMS.Models;

namespace GCPVDMS.ViewModels
{
    public class EventsImSignedUpFor
    {
        public IEnumerable<Event> EventID { get; set; }
        public IEnumerable<EventRegistration> EventRegistrations { get; set; }
    }
}
