using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class EFGCPTaskRepository : IGCPTaskRepository
    {
        private ApplicationDbContext context;
        public EFGCPTaskRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<GCPTask> GCPTasks => context.GCPTasks;

        public void SaveTask(GCPTask GCPTask)
        {
            if (GCPTask.GCPTaskID == 0)
            {
                context.GCPTasks.Add(GCPTask);
            }
            else
            {
                GCPTask dbEntry = context.GCPTasks
                .FirstOrDefault(p => p.GCPTaskID == GCPTask.GCPTaskID);
                if (dbEntry != null)
                {
                    dbEntry.TaskName = GCPTask.TaskName;
                }
            }

            //context.GCPTasks.Add(GCPTask);
            context.SaveChanges();

        }
    }
}

