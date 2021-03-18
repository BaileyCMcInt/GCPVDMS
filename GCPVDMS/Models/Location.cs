using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class Location
    {
        public int LocationID { get; set; }

        [MaxLength(250)]
        public string LocationName { get; set; }
       
        [MaxLength(250)]
        public string City { get; set; }

        [MaxLength(250)]
        public string StreetAddress { get; set; }

        [MaxLength(250)]
        public string StreetAddress2 { get; set; }

        [MaxLength(32)]
        public string Zip { get; set; }

        [ForeignKey("CountyID")]
        public int CountyID { get; set; }
        public County County { get; set; }

    }
}
