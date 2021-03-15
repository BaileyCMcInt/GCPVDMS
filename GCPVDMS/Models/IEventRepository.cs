using GCPVDMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public interface IEventRepository
    {
        IEnumerable<Event> Events { get; }

        //    void SaveEvent(Event @event);

        void SaveEvent(CreateEventViewModel viewModel);

    }
}
