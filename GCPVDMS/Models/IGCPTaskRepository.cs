using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public interface IGCPTaskRepository
    {
        IEnumerable<GCPTask> GCPTasks { get; }

        void SaveTask(GCPTask GCPTask);
    }
}
