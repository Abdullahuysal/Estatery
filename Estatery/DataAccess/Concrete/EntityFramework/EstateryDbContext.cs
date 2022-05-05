using DataAccess.Concrete.EntityFramework.Mappers;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EstateryDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-2DE1HM4\SQLEXPRESS;Database=Estatery;Integrated Security=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House>(h =>
            {
                h.HasOne(h => h.Location)
                .WithMany(l => l.Houses)
                .HasForeignKey(h => h.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

                h.HasOne(h => h.SalesType)
                .WithMany(s => s.Houses)
                .HasForeignKey(h => h.SalesTypeId)
                .OnDelete(DeleteBehavior.NoAction);

                h.HasOne(h => h.SalesCategory)
                .WithMany(s => s.Houses)
                .HasForeignKey(h => h.SalesCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            });
            modelBuilder.Entity<Land>(l =>
            {
                l.HasOne(l => l.Location)
                .WithMany(l => l.Lands)
                .HasForeignKey(l => l.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

                l.HasOne(l => l.SalesType)
               .WithMany(s => s.Lands)
               .HasForeignKey(l => l.SalesTypeId)
               .OnDelete(DeleteBehavior.NoAction);

                l.HasOne(l => l.SalesCategory)
                .WithMany(s => s.Lands)
                .HasForeignKey(l => l.SalesCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            });
            modelBuilder.Entity<WorkPlace>(w =>
            {
                w.HasOne(w => w.Location)
                .WithMany(l => l.WorkPlaces)
                .HasForeignKey(w => w.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
                w.HasOne(w => w.SalesType)
               .WithMany(s => s.WorkPlaces)
               .HasForeignKey(w => w.SalesTypeId)
               .OnDelete(DeleteBehavior.NoAction);
                w.HasOne(w => w.SalesCategory)
                .WithMany(s => s.WorkPlaces)
                .HasForeignKey(w => w.SalesCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new HouseMap());
            modelBuilder.ApplyConfiguration(new LandMap());
            modelBuilder.ApplyConfiguration(new WorkPlaceMap());
            modelBuilder.ApplyConfiguration(new SalesCategoryMap());
            modelBuilder.ApplyConfiguration(new SalesTypeMap());
            modelBuilder.ApplyConfiguration(new LocationMap());

            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, CityName = "karaman", DistrictName = "merkez" },
                new Location { Id = 2, CityName = "karaman", DistrictName = "Ayrancı" },
                new Location { Id = 3, CityName = "karaman", DistrictName = "ermenek" },
                new Location { Id = 4, CityName = "karaman", DistrictName = "kazımkarabekir" },
                new Location { Id = 5, CityName = "konya", DistrictName = "meram" },
                new Location { Id = 6, CityName = "konya", DistrictName = "selçuklu" },
                new Location { Id = 7, CityName = "mersin", DistrictName = "mezitli" },
                new Location { Id = 8, CityName = "mersin", DistrictName = "silifke" },
                new Location { Id = 9, CityName = "mersin", DistrictName = "yenişehir" },
                new Location { Id = 10, CityName = "mersin", DistrictName = "çiftlikköy" },
                new Location { Id = 11, CityName = "mersin", DistrictName = "mut" },
                new Location { Id = 12, CityName = "mersin", DistrictName = "toroslar" }

                );
            modelBuilder.Entity<SalesCategory>().HasData(
                new SalesCategory { Id = 1, Name = "apartman" },
                new SalesCategory { Id = 2, Name = "müstakil" },
                new SalesCategory { Id = 3, Name = "site" },
                new SalesCategory { Id = 4, Name = "villa" },
                new SalesCategory { Id = 5, Name = "yazlık" },
                new SalesCategory { Id = 6, Name = "tarla" },
                new SalesCategory { Id = 7, Name = "bağ" },
                new SalesCategory { Id = 8, Name = "zeytinlik" },
                new SalesCategory { Id = 9, Name = "dükkan" },
                new SalesCategory { Id = 10, Name = "ofis" },
                new SalesCategory { Id = 11, Name = "fabrika" },
                new SalesCategory { Id = 12, Name = "plaza" },
                new SalesCategory { Id = 13, Name = "büro" }

                );
            modelBuilder.Entity<SalesType>().HasData(
                new SalesType { Id = 1, Name = "satılık" },
                new SalesType { Id = 2, Name = "kiralık" },
                new SalesType { Id = 3, Name = "günlük kiralık" },
                new SalesType { Id = 4, Name = "sezonluk" }
                );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<SalesCategory> SalesCategories { get; set; }
        public DbSet<SalesType> SalesTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<HouseImageUrl> HouseImageUrls { get; set; }
        public DbSet<LandImageUrl> LandImageUrls { get; set; }
        public DbSet<WorkPlaceImageUrl> WorkPlaceImageUrls { get; set; }

    }

}
