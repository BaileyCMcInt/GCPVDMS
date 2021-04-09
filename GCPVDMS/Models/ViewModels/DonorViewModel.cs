using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models.ViewModels
{
    public class DonorViewModel
    {
        public string email_address { get; set; }
        public string transaction_initiation_date { get; set; }
        public string transaction_value { get; set; }
        public string transaction_status { get; set; }
        public List<Donor> Donors { get; set; }
    }
}
