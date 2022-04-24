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
    public class EstateryDbContext:DbContext
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
                .WithOne(l => l.House)
                .HasForeignKey<House>(h => h.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

                h.HasOne(h => h.SalesType)
                .WithMany(s => s.Houses)
                .HasForeignKey(h => h.SalesTypeId)
                .OnDelete(DeleteBehavior.NoAction);

                h.HasOne(h => h.SalesCategory)
                .WithMany(s => s.Houses)
                .HasForeignKey(h=>h.SalesCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Land>(l =>
            {
                l.HasOne(l => l.Location)
                .WithOne(l=>l.Land)
                .HasForeignKey<Land>(l=>l.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

                l.HasOne(l => l.SalesType)
               .WithMany(s=>s.Lands)
               .HasForeignKey(l => l.SalesTypeId)
               .OnDelete(DeleteBehavior.NoAction);

                l.HasOne(l => l.SalesCategory)
                .WithMany(s=>s.Lands)
                .HasForeignKey(l => l.SalesCategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<WorkPlace>(w =>
            {
                w.HasOne(w => w.Location)
                .WithOne(l => l.WorkPlace)
                .HasForeignKey<WorkPlace>(w => w.LocationId)
                .OnDelete(DeleteBehavior.Cascade);

                w.HasOne(w => w.SalesType)
               .WithMany(s=>s.WorkPlaces)
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
            modelBuilder.ApplyConfiguration(new ImageUrlMap());
            modelBuilder.ApplyConfiguration(new SalesCategoryMap());
            modelBuilder.ApplyConfiguration(new SalesTypeMap());
            modelBuilder.ApplyConfiguration(new LocationMap());

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Land> Lands { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        public DbSet<SalesCategory> SalesCategories { get; set; }
        public DbSet<SalesType> SalesTypes { get; set; }
        public DbSet<ImageUrl> ImageUrls { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
    
}
