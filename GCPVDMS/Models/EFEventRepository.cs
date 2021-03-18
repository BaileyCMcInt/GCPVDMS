using GCPVDMS.Models.ViewModels;
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

        public void SaveEvent(CreateEventViewModel viewModel)
        {
            //if this a newly created event and thus the eventID == 0, add a new event to the Events table.
            //and the tasks to the EventTask table with the newly created eventID. 
            if (viewModel.Event.EventID == 0)
            {
                context.Events.Add(viewModel.Event);
                context.SaveChanges();

                viewModel.GCPEventTasks.ForEach(EventTask => EventTask.EventID = viewModel.Event.EventID);
                context.GCPEventTasks.AddRange(viewModel.GCPEventTasks);
                context.SaveChanges();

            }
            //if this is not a new event, pull the event info and the EventTasks from the context and update accordingly
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
