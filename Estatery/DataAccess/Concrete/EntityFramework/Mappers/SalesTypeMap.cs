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
    public class SalesTypeMap : IEntityTypeConfiguration<SalesType>
    {
        public void Configure(EntityTypeBuilder<SalesType> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                .ValueGeneratedOnAdd();
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
