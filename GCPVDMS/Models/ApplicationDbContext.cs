﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GCPVDMS.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options) { }
        public DbSet<Drive> Drives { get; set; }

        public DbSet<County> Counties { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<VolunteerGroup> VolunteerGroups { get; set; }

        public DbSet<GCPTask> GCPTasks { get; set; }

        public DbSet<GCPEventTask> GCPEventTasks { get; set; }
      
        public DbSet<EventRegistration> EventRegistrations { get; set; }


        public DbSet<VolunteerHour> VolunteerHours { get; set; }

        public DbSet<Disclaimer> Disclaimers { get; set; }

        public DbSet<Donor> Donors{ get; set; }
        public DbSet<GCPEventDisclaimer> EventDisclaimers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventRegistration>().HasIndex(p => new 
            {
                p.EventID, p.UserId
            })
                .IsUnique();

        }
    
    }
}
