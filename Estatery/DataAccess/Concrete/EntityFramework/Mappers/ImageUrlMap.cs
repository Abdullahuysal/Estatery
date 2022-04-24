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
    public class ImageUrlMap : IEntityTypeConfiguration<ImageUrl>
    {
        public void Configure(EntityTypeBuilder<ImageUrl> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                        .ValueGeneratedOnAdd();
            builder.Property(i => i.Url)
                        .IsRequired()
                        .HasMaxLength(150);
        }
    }
}
