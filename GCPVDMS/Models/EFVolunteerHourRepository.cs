using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    //this class is where the logic lives for staring the volunteer hours into the volunteer hour
    //table. 
    public class EFVolunteerHourRepository : IVolunteerHourRepository
    {
        private ApplicationDbContext context;
        public EFVolunteerHourRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        //list of volunteer hour objects
        public IEnumerable<VolunteerHour> VolunteerHours => context.VolunteerHours;

        //saves the volunteerhour object into the datbase
        public void SaveVolunteerHour(VolunteerHour @volunteerhour)
        {
            //first instance of VolunteerHourID starts at 0, then increments by 1
            if (volunteerhour.VolunteerHourID == 0)
            {
                context.VolunteerHours.Add(@volunteerhour);
            }
            else
            {
                VolunteerHour dbEntry = context.VolunteerHours
                .FirstOrDefault(p => p.VolunteerHourID == volunteerhour.VolunteerHourID);
                if (dbEntry != null)
                {
                    dbEntry.UserId = volunteerhour.UserId;
                    dbEntry.Date = @volunteerhour.Date;
                    dbEntry.NumberOfHours = @volunteerhour.NumberOfHours;
                    dbEntry.EventID = volunteerhour.EventID;
                    dbEntry.StartTime = volunteerhour.StartTime;
                    dbEntry.EndTime = volunteerhour.EndTime;
                    dbEntry.volunteerHourDate = volunteerhour.volunteerHourDate;
                }

            }
            //saves the changes in the db table when referenced from controller
            context.SaveChanges();
        }
    }
}