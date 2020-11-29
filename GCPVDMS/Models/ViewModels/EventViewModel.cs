using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GCPVDMS.Models.ViewModels
{
    public class EventViewModel
    {
        public IEnumerable<Event> Events { get; set; }

        public IEnumerable<County> Counties { get; set; }

        public IEnumerable<Location> Locations { get; set; }
    }
}
