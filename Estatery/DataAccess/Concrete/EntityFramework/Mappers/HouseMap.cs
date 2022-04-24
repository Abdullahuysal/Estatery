using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mappers
{
    public class HouseMap : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.Property(h => h.CreatedAt)
                        .IsRequired()
                        .HasDefaultValue(DateTime.Now);
            builder.Property(h => h.UpdatedAt)
                        .IsRequired()
                        .HasDefaultValue(DateTime.Now);
            builder.Property(h => h.Advertiser)
                        .IsRequired()
                        .HasMaxLength(50);
            builder.Property(h => h.ConstructionYear)
                        .IsRequired();
            builder.Property(h => h.NumberOfRooms)
                        .IsRequired();
            builder.Property(h => h.NumberOfBath)
                        .IsRequired();
            builder.Property(h => h.SquareMeter)
                        .IsRequired();    
        }
    }
}
