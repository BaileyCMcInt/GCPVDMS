﻿using GCPVDMS.Models.ViewModels;
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
            //add tasks to the EventTask table with the newly created eventID. 
            //add disclaimers to the EventDisclaimer table with the newly created eventID.
            if (viewModel.Event.EventID == 0)
            {
                context.Events.Add(viewModel.Event);
                context.SaveChanges();

                viewModel.GCPEventTasks.ForEach(EventTask => EventTask.EventID = viewModel.Event.EventID);
                context.GCPEventTasks.AddRange(viewModel.GCPEventTasks);
                context.SaveChanges();
                viewModel.GCPEventDisclaimers.ForEach(EventDisclaimer => EventDisclaimer.EventID = viewModel.Event.EventID);
                context.EventDisclaimers.AddRange(viewModel.GCPEventDisclaimers);
                context.SaveChanges();

            }
            //else this is not a new event, pull the event info, EventTasks, and EventDisclaimers from the context and update accordingly
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
                 //   dbEntry.NumVolunteersSignedUp = viewModel.Event.NumVolunteersSignedUp; //!!Do NOT include this or it will make this number 0 upon saving!
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

                viewModel.GCPEventDisclaimers.ForEach(disclaimerFromViewModel =>
                {
                    var disclaimer = context.EventDisclaimers.Where(disclaimerFromDatabase => disclaimerFromViewModel.GCPEventDisclaimerID == disclaimerFromDatabase.GCPEventDisclaimerID).FirstOrDefault();
                    disclaimer.isSelected = disclaimerFromViewModel.isSelected;
                });
                context.SaveChanges();
            }

        }
    }
}
