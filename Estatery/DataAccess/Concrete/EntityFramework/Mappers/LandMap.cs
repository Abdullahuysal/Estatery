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
    public class LandMap : IEntityTypeConfiguration<Land>
    {
        public void Configure(EntityTypeBuilder<Land> builder)
        {
            builder.Property(l => l.CreatedAt)
                        .IsRequired()
                        .HasDefaultValue(DateTime.Now);
            builder.Property(l => l.UpdatedAt)
                        .IsRequired()
                        .HasDefaultValue(DateTime.Now);
            builder.Property(l => l.Advertiser)
                        .IsRequired()
                        .HasMaxLength(50);
            builder.Property(l => l.Price)
                        .IsRequired();
            builder.Property(l => l.SquareMeter)
                        .IsRequired();
        }
    }
}
