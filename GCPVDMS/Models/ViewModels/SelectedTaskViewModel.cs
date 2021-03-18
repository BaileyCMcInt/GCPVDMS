using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models.ViewModels
{
    public class SelectedTaskViewModel
    {
        public int EventID { get; set; }

        public int GCPTaskId { get; set; }

        public string GCPTaskName { get; set; }

        public bool IsSelected { get; set; }

        // public int[] SelectedTasks { get; set; }
    }
}
