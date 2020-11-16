using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class EFDriveRepository: IDriveRepository
 {
    private ApplicationDbContext context;
    public EFDriveRepository(ApplicationDbContext ctx)
    {
        context = ctx;
    }
    public IEnumerable<Drive> Drives => context.Drives;
    }
}
