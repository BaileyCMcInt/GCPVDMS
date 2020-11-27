using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public interface IEventRepository
    {
        IEnumerable<Event> Events { get; }
    }
}
