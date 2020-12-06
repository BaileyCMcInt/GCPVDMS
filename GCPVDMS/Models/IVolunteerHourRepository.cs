using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public interface IVolunteerHourRepository
    {
        IEnumerable<VolunteerHour> VolunteerHours { get; }

        void SaveVolunteerHour(VolunteerHour @volunteerhour);

    }
}
