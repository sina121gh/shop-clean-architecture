using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.UserName)
                .IsUnique();

            builder.HasIndex(u =>u.Email)
                .IsUnique();

            builder.Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Salt)
                .HasMaxLength(31)
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(u => u.IsAdmin)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
