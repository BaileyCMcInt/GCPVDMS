using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class County
    {
            public int CountyID { get; set; }

            [MaxLength(250)]
            public string CountyName { get; set; }
        
            [MaxLength(250)]
            public string CountyState { get; set; }
    }
}
