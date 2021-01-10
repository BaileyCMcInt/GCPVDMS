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

        public string City { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public string Zip { get; set; }

        [ForeignKey("CountyID")]
        public int CountyID { get; set; }
        public County County { get; set; }

    }
}
