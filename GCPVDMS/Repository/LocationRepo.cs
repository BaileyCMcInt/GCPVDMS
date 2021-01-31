using GCPVDMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Repository
{
    public class LocationRepo
    {
        private ApplicationDbContext context;
        public LocationRepo(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Location> Locations => context.Locations;
    }
}
