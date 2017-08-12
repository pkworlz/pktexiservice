using pktexiservice.Models.dynamic;
using pktexiservice.Models.Level1;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pktexiservice.Models
{
    public class TexiDbContext:DbContext
    {
        public DbSet<Cab> Cabs { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<DriverStatus> DriverStatus { get; set; }

        public TexiDbContext(): base("DefaultConnection")
        {

        }
    }
}