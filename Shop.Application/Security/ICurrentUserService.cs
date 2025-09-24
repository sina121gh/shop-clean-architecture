using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Security
{
    public interface ICurrentUserService
    {
        int? UserId { get; }
        int? RoleId { get; }
        string? UserName { get; }
        string? Email { get; }
        string? SecretCode { get; }
        bool IsAuthenticated { get; }
    }
}
