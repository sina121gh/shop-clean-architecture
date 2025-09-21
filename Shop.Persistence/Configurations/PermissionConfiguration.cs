using Application.Common.Security;
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
            // Users
            new Permission { Id = Permissions.Users.Id, Title = Permissions.Users.Name },
            new Permission { Id = Permissions.Users.Actions.CreateId, Title = Permissions.Users.Actions.CreateName,
                ParentId = Permissions.Users.Id },
            new Permission { Id = Permissions.Users.Actions.UpdateId, Title = Permissions.Users.Actions.UpdateName,
                ParentId = Permissions.Users.Id },
            new Permission { Id = Permissions.Users.Actions.DeleteId, Title = Permissions.Users.Actions.DeleteName,
                ParentId = Permissions.Users.Id },
            new Permission { Id = Permissions.Users.Actions.ViewId, Title = Permissions.Users.Actions.ViewName,
                ParentId = Permissions.Users.Id },

            // Categories
            new Permission { Id = Permissions.Categories.Id, Title = Permissions.Categories.Name },
            new Permission { Id = Permissions.Categories.Actions.CreateId, Title = Permissions.Categories.Actions.CreateName,
                ParentId = Permissions.Categories.Id },
            new Permission { Id = Permissions.Categories.Actions.UpdateId, Title = Permissions.Categories.Actions.UpdateName,
                ParentId = Permissions.Categories.Id },
            new Permission { Id = Permissions.Categories.Actions.DeleteId, Title = Permissions.Categories.Actions.DeleteName,
                ParentId = Permissions.Categories.Id },
            new Permission { Id = Permissions.Categories.Actions.ViewId, Title = Permissions.Categories.Actions.ViewName,
                ParentId = Permissions.Categories.Id },

            // Products
            new Permission { Id = Permissions.Products.Id, Title = Permissions.Products.Name },
            new Permission { Id = Permissions.Products.Actions.CreateId, Title = Permissions.Products.Actions.CreateName,
                ParentId = Permissions.Products.Id },
            new Permission { Id = Permissions.Products.Actions.UpdateId, Title = Permissions.Products.Actions.UpdateName,
                ParentId = Permissions.Products.Id },
            new Permission { Id = Permissions.Products.Actions.DeleteId, Title = Permissions.Products.Actions.DeleteName,
                ParentId = Permissions.Products.Id },
            new Permission { Id = Permissions.Products.Actions.ViewId, Title = Permissions.Products.Actions.ViewName,
                ParentId = Permissions.Products.Id }
        );

        }
    }
}
