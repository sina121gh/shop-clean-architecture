using Shop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Permission : BaseEntity
    {
        public string Title { get; set; }

        public int? ParentId { get; set; }

        public Permission? ParentPermission { get; set; }

        public ICollection<Permission>? ChildPermissions { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
