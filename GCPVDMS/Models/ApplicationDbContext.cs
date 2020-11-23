﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GCPVDMS.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options) { }
        public DbSet<Drive> Drives { get; set; }

        public DbSet<County> Counties { get; set; }

        public DbSet<Location> Locations { get; set; }

    }
}