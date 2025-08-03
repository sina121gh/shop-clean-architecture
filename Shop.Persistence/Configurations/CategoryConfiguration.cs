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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasData(
                new Category { Id = 1, Name = "ورزشی" },
                new Category { Id = 2, Name = "خانه" },
                new Category { Id = 3, Name = "موبایل" },
                new Category { Id = 4, Name = "لپ تاپ" },
                new Category { Id = 5, Name = "کامپیوتر" }
                );
        }
    }
}
