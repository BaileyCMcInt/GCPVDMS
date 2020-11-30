using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class EFEventRepository : IEventRepository
    {
        private ApplicationDbContext context;
        public EFEventRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Event> Events => context.Events;

        public void SaveEvent(Event @event)
        {
            if (@event.EventID == 0)
            {
                context.Events.Add(@event);
            }
            else
            {
                Event dbEntry = context.Events
                .FirstOrDefault(p => p.EventID == @event.EventID);
                if (dbEntry != null)
                {
                    dbEntry.EventTitle = @event.EventTitle;
                    dbEntry.EventDate = @event.EventDate;
                    dbEntry.StartTime = @event.StartTime;
                    dbEntry.EndTime = @event.EndTime; 
                    dbEntry.EventDescription = @event.EventDescription;
                    dbEntry.POCName = @event.POCName;
                    dbEntry.POCPhone = @event.POCPhone;
                    dbEntry.POCEmail = @event.POCEmail;
                    dbEntry.isEventActive = @event.isEventActive;
                    dbEntry.LocationID = @event.LocationID;
                }
        }
      context.SaveChanges();
    }
  }
}