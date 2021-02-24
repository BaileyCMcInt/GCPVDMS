using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class LocationDTO
    {

        public Location GCPLocationData { get; set; }
        public List<Location> LocationList { get; set; }

        public County County { get; set; }

        public List<County> Counties { get; set; }

    }
}
