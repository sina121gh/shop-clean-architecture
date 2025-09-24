using Application.Common.Security;
using Microsoft.AspNetCore.Http;
using Shop.Application.Contracts.Infrastructure;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Security
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int? UserId =>
        int.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId)
            ? userId
            : null;

        public string? UserName =>
        _httpContextAccessor.HttpContext?.User?.Identity?.Name;

        public string? Email => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Email)?.Value;

        public bool IsAuthenticated =>
        _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

        public string? SecretCode => _httpContextAccessor.HttpContext?.User?.FindFirst("SecretCode")?.Value;

        public int? RoleId =>
        int.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value, out var roleId)
            ? roleId
            : null;
    }
}
