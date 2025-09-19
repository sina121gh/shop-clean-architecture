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
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(p => p.ParentPermission)
                .WithMany(p => p.ChildPermissions)
                .HasForeignKey(p => p.ParentId)
                .IsRequired(false);

            builder.HasData(
                // --- مدیریت کاربران ---
                new Permission { Id = 1, Title = "مدیریت کاربران", ParentId = null },

                new Permission { Id = 2, Title = "مشاهده کاربران", ParentId = 1 },
                new Permission { Id = 3, Title = "ایجاد کاربر", ParentId = 1 },
                new Permission { Id = 4, Title = "ویرایش کاربر", ParentId = 1 },
                new Permission { Id = 5, Title = "حذف کاربر", ParentId = 1 },

                // --- مدیریت دسته‌بندی‌ها ---
                new Permission { Id = 6, Title = "مدیریت دسته‌بندی‌ها", ParentId = null },

                new Permission { Id = 7, Title = "مشاهده دسته‌بندی‌ها", ParentId = 6 },
                new Permission { Id = 8, Title = "ایجاد دسته‌بندی", ParentId = 6 },
                new Permission { Id = 9, Title = "ویرایش دسته‌بندی", ParentId = 6 },
                new Permission { Id = 10, Title = "حذف دسته‌بندی", ParentId = 6 },

                // --- مدیریت محصولات ---
                new Permission { Id = 11, Title = "مدیریت محصولات", ParentId = null },

                new Permission { Id = 12, Title = "مشاهده محصولات", ParentId = 11 },
                new Permission { Id = 13, Title = "ایجاد محصول", ParentId = 11 },
                new Permission { Id = 14, Title = "ویرایش محصول", ParentId = 11 },
                new Permission { Id = 15, Title = "حذف محصول", ParentId = 11 }
            );

        }
    }
}
