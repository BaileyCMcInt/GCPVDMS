using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public interface IDonorRepository
    {
        IEnumerable<Donor> Donors { get; }

        void SaveDonor(Donor donor);
    }
}
