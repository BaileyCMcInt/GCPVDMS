using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace GCPVDMS.Models
{
    [Table("GCPEventTasks")]
    public class GCPEventTask
    {
        public int GCPEventTaskID { get; set; }

        public int EventID { get; set; }

        [ForeignKey("EventID")]
        public Event Event { get; set; }

        public int GCPTaskID { get; set; }

        [ForeignKey("GCPTaskID")]
        public GCPTask GCPTask { get; set; }

        public bool isSelected { get; set; }
    }
}

