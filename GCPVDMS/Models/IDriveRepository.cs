using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public interface IDriveRepository
    {
        IEnumerable<Drive> Drives { get; }
    }
}
