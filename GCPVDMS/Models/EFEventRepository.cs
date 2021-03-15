using GCPVDMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//namespace GCPVDMS.Models
//{
//  public class EFEventRepository : IEventRepository
//  {
//      private ApplicationDbContext context;
//      public EFEventRepository(ApplicationDbContext ctx)
//      {
//          context = ctx;
//      }
//      public IEnumerable<Event> Events => context.Events;

//      public void SaveEvent(Event @event)
//      {
//          if (@event.EventID == 0)
//          {
//              context.Events.Add(@event);
//          }
//          else
//          {
//              Event dbEntry = context.Events
//              .FirstOrDefault(p => p.EventID == @event.EventID);
//              if (dbEntry != null)
//              {
//                  dbEntry.EventTitle = @event.EventTitle;
//                  dbEntry.EventDate = @event.EventDate;
//                  dbEntry.StartTime = @event.StartTime;
//                  dbEntry.EndTime = @event.EndTime; 
//                  dbEntry.EventDescription = @event.EventDescription;
//                  dbEntry.NumVolunteersNeeded = @event.NumVolunteersNeeded;
//                  dbEntry.POCName = @event.POCName;
//                  dbEntry.POCPhone = @event.POCPhone;
//                  dbEntry.POCEmail = @event.POCEmail;
//                  dbEntry.isEventActive = @event.isEventActive;
//                  dbEntry.LocationID = @event.LocationID;
//              }
//      }
//    context.SaveChanges();
//  }
//}
//}

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
        //  public void SaveEvent(Event @event)
        public void SaveEvent(CreateEventViewModel viewModel)
        {
            //   if (@event.EventID == 0)
            if (viewModel.Event.EventID == 0)
            {
                //   context.Events.Add(@event);
                context.Events.Add(viewModel.Event);
                //foreach (GCPTask gcptask in viewModel.GCPTasks)
                //{
                //    context.GCPEventTasks.Add(gcptask);
                //}
            }
            else
            {
                Event dbEntry = context.Events
                .FirstOrDefault(p => p.EventID == viewModel.Event.EventID);
                if (dbEntry != null)
                {
                    dbEntry.EventTitle = viewModel.Event.EventTitle;
                    dbEntry.EventDate = viewModel.Event.EventDate;
                    dbEntry.StartTime = viewModel.Event.StartTime;
                    dbEntry.EndTime = viewModel.Event.EndTime;
                    dbEntry.EventDescription = viewModel.Event.EventDescription;
                    dbEntry.NumVolunteersNeeded = viewModel.Event.NumVolunteersNeeded;
                    dbEntry.POCName = viewModel.Event.POCName;
                    dbEntry.POCPhone = viewModel.Event.POCPhone;
                    dbEntry.POCEmail = viewModel.Event.POCEmail;
                    dbEntry.isEventActive = viewModel.Event.isEventActive;
                    dbEntry.LocationID = viewModel.Event.LocationID;
                }
                //Get EventTask context. Create record for each task. Only create from blank when creating an event for the first time.
                //check eventask table where eventID is null. first or default and you want it to be null.
                //GCPEventTask dbEventTask = context.GCPEventTasks
                //            .FirstOrDefault(p => p.EventID == viewModel.Event.EventID);
                //if (dbEventTask != null)
                //{
                //    foreach (var lst in viewModel.SelectedTasks)
                //    {
                //        dbEventTask.isSelected = viewModel.GCPEventTask.isSelected;
                //    }
                //}
            }
            context.SaveChanges();
        }
    }
}
