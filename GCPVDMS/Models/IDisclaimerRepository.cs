using GCPVDMS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public interface IDisclaimerRepository
    {
        IEnumerable<Disclaimer> Disclaimers { get; }

        //    void SaveEvent(Event @event);

        void SaveDisclaimer(Disclaimer disclaimer);

    }
}

