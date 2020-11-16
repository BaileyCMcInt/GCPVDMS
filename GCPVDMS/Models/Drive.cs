using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class Drive
    {
        public int DriveID { get; set; }
        public string Name { get; set; }
        public DateTime StartTime{ get; set; }
        public DateTime EndTime { get; set; }
    }
}
