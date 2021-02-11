using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public interface IEventRegistrationRepository
    {
        IEnumerable<EventRegistration> EventRegistrations { get; }

        void SaveEventRegistration(EventRegistration eventRegistration);
    }
}
