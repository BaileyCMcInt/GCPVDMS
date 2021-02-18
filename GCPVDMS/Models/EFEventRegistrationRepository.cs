using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GCPVDMS.Models

{
    public class EFEventRegistrationRepository : IEventRegistrationRepository
        {

       

        private ApplicationDbContext context;
            public EFEventRegistrationRepository(ApplicationDbContext ctx)
            {
                context = ctx;
            }
            public IEnumerable<EventRegistration> EventRegistrations => context.EventRegistrations;

            public void SaveEventRegistration(EventRegistration eventRegistration)
            {
                if (eventRegistration.EventRegistrationID == 0)
                {
                    context.EventRegistrations.Add(eventRegistration);
                }
                else
                {
                    EventRegistration dbEntry = context.EventRegistrations
                    .FirstOrDefault(p => p.EventRegistrationID == eventRegistration.EventRegistrationID);
                    if (dbEntry != null)
                    {
                        dbEntry.EventID= eventRegistration.EventID;
                        dbEntry.UserId = eventRegistration.UserId;
                        dbEntry.Event = eventRegistration.Event;
                        
                    }
                }
                context.SaveChanges();
        
        }

    }

}

