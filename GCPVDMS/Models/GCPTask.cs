using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class GCPTask
    {
        public int GCPTaskID { get; set; }

        [MaxLength(250)]
        public string TaskName { get; set; }
    }
}
