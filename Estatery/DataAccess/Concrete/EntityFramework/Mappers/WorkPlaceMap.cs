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
    public class WorkPlaceMap : IEntityTypeConfiguration<WorkPlace>
    {
        public void Configure(EntityTypeBuilder<WorkPlace> builder)
        {
            builder.Property(w => w.CreatedAt)
                        .IsRequired()
                        .HasDefaultValue(DateTime.Now);
            builder.Property(w => w.UpdatedAt)
                        .IsRequired()
                        .HasDefaultValue(DateTime.Now);
            builder.Property(w => w.Advertiser)
                        .IsRequired()
                        .HasMaxLength(50);
            builder.Property(w => w.Price)
                        .IsRequired();
            builder.Property(w => w.SquareMeter)
                        .IsRequired();
            builder.HasOne(w => w.Location)
                    .WithOne();

        }
    }
}
