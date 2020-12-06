using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class EFVolunteerHourRepository : IVolunteerHourRepository
    {
        private ApplicationDbContext context;
        public EFVolunteerHourRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<VolunteerHour> VolunteerHours => context.VolunteerHours;

        public void SaveVolunteerHour(VolunteerHour @volunteerhour)
        {
            
                context.VolunteerHours.Add(@volunteerhour);
            
            context.SaveChanges();
        }
    }
}