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
                context.SaveChanges();
                viewModel.GCPEventTasks.ForEach(EventTask => EventTask.EventID = viewModel.Event.EventID);
                context.GCPEventTasks.AddRange(viewModel.GCPEventTasks);
                context.SaveChanges();

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

                viewModel.GCPEventTasks.ForEach(taskFromViewModel =>
                {
                    var task = context.GCPEventTasks.Where(taskFromDatabase => taskFromViewModel.GCPEventTaskID == taskFromDatabase.GCPEventTaskID).FirstOrDefault();
                    task.isSelected = taskFromViewModel.isSelected;
                });
                context.SaveChanges();

            }

        }
    }
}
