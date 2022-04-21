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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                            .ValueGeneratedOnAdd();
            builder.Property(u => u.FirstName)
                            .IsRequired()
                            .HasMaxLength(50);
            builder.Property(u => u.SecondName)
                            .IsRequired()
                            .HasMaxLength(50);
            builder.Property(u => u.Email)
                            .IsRequired()
                            .HasMaxLength(150);
            builder.Property(u => u.Password)
                            .IsRequired()
                            .HasMaxLength(100);
            builder.Property(u => u.Active)
                            .IsRequired()
                            .HasDefaultValue(true);
            builder.HasOne(u => u.Role)
                            .WithMany(r => r.Users)
                            .HasForeignKey(u => u.RoleId);
        }
    }
}
