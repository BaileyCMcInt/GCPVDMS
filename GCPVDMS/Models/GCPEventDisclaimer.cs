using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace GCPVDMS.Models
{
    public class GCPEventDisclaimer
    {
        public int GCPEventDisclaimerID { get; set; }

        public int EventID { get; set; }

        [ForeignKey("EventID")]
        public Event Event { get; set; }

        public int DisclaimerID { get; set; }

        [ForeignKey("DisclaimerID")]
        public Disclaimer Disclaimer { get; set; }
        public bool isSelected { get; set; }
    }
}

