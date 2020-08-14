using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalculation.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Holiday> Holidays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed country

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, Name = "Turkey", Currency = "TR" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, Name = "United Arab Emirates", Currency = "AE" });


            //seed holidays
            modelBuilder.Entity<Holiday>().HasData(new Holiday { HolidayId = 1, Name = "Eid", Date = new DateTime(2020, 8, 1), CountryId = 1 });
            modelBuilder.Entity<Holiday>().HasData(new Holiday { HolidayId = 2, Name = "Eid", Date = new DateTime(2020, 8, 2), CountryId = 1 });
            modelBuilder.Entity<Holiday>().HasData(new Holiday { HolidayId = 3, Name = "Eid", Date = new DateTime(2020, 8, 3), CountryId = 1 });
            modelBuilder.Entity<Holiday>().HasData(new Holiday { HolidayId = 4, Name = "30 Ağustos Zafer Bayramı", Date = new DateTime(2020, 8, 30), CountryId = 1 });

        }
    }
}
