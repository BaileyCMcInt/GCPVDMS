using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace GCPVDMS.Models
{
    public class GCPEventTask
    {
        public int GCPEventTaskID { get; set; }

        [ForeignKey("EventID")]
        public int EventID { get; set; }
        public Event Event { get; set; }

        [ForeignKey("TaskID")]
        public int GCPTaskID { get; set; }
        public GCPTask GCPTask { get; set; }

        public bool isSelected { get; set; }
    }
}
