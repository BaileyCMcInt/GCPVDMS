using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }

        [ForeignKey("CountyID")]
        public int CountyID { get; set; }
        public County County { get; set; }

    }
}
