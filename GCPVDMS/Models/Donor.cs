using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class Donor
    {
        public int donorId { get; set; }

        public string email_address { get; set; }

        public string transaction_id { get; set; }

        public string transaction_initiation_date { get; set; }

        public string currency_code { get; set; }

        public string transaction_value { get; set; }
        
        public string transaction_status { get; set; }

        public string given_name { get; set; }

        public string surname { get; set; }
        
        public string alt_full_name { get; set; }
      
    }
}
 