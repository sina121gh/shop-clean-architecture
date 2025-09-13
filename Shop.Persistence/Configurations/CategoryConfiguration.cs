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

            #region Seed Data

            builder.HasData(
                new Category { Id = 1, Name = "لوازم ورزشی" },
                new Category { Id = 2, Name = "لوازم خانگی" },
                new Category { Id = 3, Name = "موبایل و تبلت" },
                new Category { Id = 4, Name = "لپ‌تاپ و لوازم جانبی" },
                new Category { Id = 5, Name = "کامپیوتر و قطعات" },
                new Category { Id = 6, Name = "پوشاک و مد" }
            );

            #endregion

        }
    }
}
