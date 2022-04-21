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

    }
    
}
