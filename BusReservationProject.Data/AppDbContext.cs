using BusReservationProject.Core.Models;
using BusReservationProject.Data.Configurations;
using BusReservationProject.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusReservationProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts):base(opts)
        {

        }

        public DbSet<Buses> Buses{ get; set; }
        public DbSet<Destinations> Destinations{ get; set; }
        public DbSet<Seats> Seats{ get; set; }
        public DbSet<AppUser> Users{ get; set; }
        public DbSet<AppUserRoles> UserRoles{ get; set; }
        public DbSet<Tickets> Tickets{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new DestinationConfiguration());
            modelBuilder.ApplyConfiguration(new SeatConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            modelBuilder.Entity<Destinations>().HasMany(x => x.Buses).WithOne(x=>x.Destinations);
            modelBuilder.Entity<Tickets>().HasOne(x => x.Users).WithMany(x=>x.Tickets);
            modelBuilder.Entity<Tickets>().HasOne(x => x.Buses).WithMany(x=>x.Tickets);
            modelBuilder.Entity<Tickets>().HasOne(x => x.Seats).WithMany(x=>x.Tickets);

        }
    }
}
