using AlwaysGreen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlwaysGreen.DAL.Context
{
    public class AlwaysgreenContext: DbContext
    {
        //NOT Abstract class
        //NOT Enum
        public DbSet<Emptybottle> Emptybottles {  get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Siret> Sirets { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Depot> Depot { get; set; }
        public DbSet<Particular> Particulars { get; set; }
        public DbSet<Login> Logins { get; set; }

        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Transport> Transports { get; set; }

        //Tab intermediaria di many to many --> DbSet? : si perché ha delle properties in più
        public DbSet<Delivery> Deliveries { get; set; }

        public AlwaysgreenContext(DbContextOptions options) : base(options) { }

        //Seeders
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<T>().HasData(DataSeeders.InitMyT());

            //Many to Many:
            modelBuilder.Entity<Emptybottle>()
                .HasMany(e => e.Transports)
                .WithMany(e => e.Emptybottles)
                .UsingEntity<Delivery>(
                //l => l.HasOne<Transport>().WithMany(e => e.Deliveries),
                //r => r.HasOne<Emptybottle>().WithMany(e => e.Deliveries)
                );

            // qui' specifico che PK é una key composta: dalle due keyes
            modelBuilder.Entity<Delivery>().HasKey(d => new { d.TransportId, d.EmptybottleId });
        }


    }
}
