using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GCPVDMS.Models

{
    public class EFDonorRepository : IDonorRepository
    {



        private readonly ApplicationDbContext context;
        public EFDonorRepository (ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Donor> Donors => context.Donors;

        public void SaveDonor(Donor donor)
        {
            if (donor.donorId == 0)
            {
                context.Donors.Add(donor);
            }
            else
            {
                Donor dbEntry = context.Donors
                .FirstOrDefault(p => p.donorId == donor.donorId);
                if (dbEntry != null)
                {
                    dbEntry.given_name = donor.given_name;
                    dbEntry.surname = donor.surname;
                    dbEntry.transaction_id = donor.transaction_id;
                    dbEntry.transaction_initiation_date = donor.transaction_initiation_date;
                    dbEntry.transaction_status = donor.transaction_status;
                    dbEntry.transaction_value = donor.transaction_value;
                    dbEntry.alt_full_name = donor.alt_full_name;
                    dbEntry.currency_code = donor.currency_code;

                }
            }
            context.SaveChanges();

        }

    }

}
