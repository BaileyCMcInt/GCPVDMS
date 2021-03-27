using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCPVDMS.Models
{
    public class EFDisclaimerRepository : IDisclaimerRepository
    {
        private ApplicationDbContext context;
        public EFDisclaimerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Disclaimer> Disclaimers => context.Disclaimers;

        public void SaveDisclaimer(Disclaimer Disclaimer)
        {
            if (Disclaimer.DisclaimerID == 0)
            {
                context.Disclaimers.Add(Disclaimer);
            }
            else
            {
                Disclaimer dbEntry = context.Disclaimers
                .FirstOrDefault(p => p.DisclaimerID == Disclaimer.DisclaimerID);
                if (dbEntry != null)
                {
                    dbEntry.DisclaimerDesc = Disclaimer.DisclaimerDesc;
                }
            }

            context.SaveChanges();

        }
    }
}
