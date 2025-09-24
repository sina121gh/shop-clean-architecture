using Application.Common.Errors;
using Application.Common.Security;
using Shop.Application.Contracts.Persistence;
using Shop.Application.Security;
using Shop.Domain.Entities;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    where TResponse : IErrorOr
{
    #region Ctor

    private readonly ICurrentUserService _currentUser;
    private readonly ICacheService _cacheService;
    private readonly IPermissionRepository _permissionRepository;

    public AuthorizationBehaviour(ICurrentUserService currentUser,
        ICacheService cacheService,
        IPermissionRepository permissionRepository)
    {
        _currentUser = currentUser;
        _cacheService = cacheService;
        _permissionRepository = permissionRepository;
    }

    #endregion

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        int userId = 0;

        // Authentication Check
        if (request is IRequireAuthorization)
        {
            if (!_currentUser.IsAuthenticated)
                return (dynamic)Errors.Authorization.Unauthorized;

            userId = _currentUser.UserId.Value;

            if (_currentUser.SecretCode == null 
                || await _cacheService.GetUserSecretCodeAsync(userId) != _currentUser.SecretCode)
                return (dynamic)Errors.Authorization.Unauthorized;
        }


        if (request is IRequirePermission permReq && request is IRequireOwnership ownReq)
        {
            var isOwner = userId == ownReq.ResourceOwnerId;
            var hasPermission = await HasPermissionAsync(userId, permReq.Permission);

            if (!isOwner && !hasPermission)
                return (dynamic)Errors.Authorization.Forbidden(permReq.Permission);
        }
        else if (request is IRequirePermission permOnly)
        {
            if (!await HasPermissionAsync(userId, permOnly.Permission))
                return (dynamic)Errors.Authorization.Forbidden(permOnly.Permission);
        }
        else if (request is IRequireOwnership ownOnly)
        {
            if (userId != ownOnly.ResourceOwnerId)
                return (dynamic)Errors.Authorization.NotOwner;
        }

        return await next();
    }

    private async Task<bool> HasPermissionAsync(int userId, string permissionName)
    {
        if (userId == 0) return false;
        int roleId = _currentUser.RoleId.Value;

        string permissions = await _cacheService.GetRolePermissionsAsync(roleId);
        if (permissions is null)
        {
            var rolePermissions = await _permissionRepository.GetPermissionsIdsOfRoleAsync(roleId);
            permissions = System.String.Join(", ", rolePermissions);
            await _cacheService.SetRolePermissionsAsync(roleId, permissions);
        }

        if (!PermissionDictionary.NameToId.TryGetValue(permissionName, out var permissionId))
            return false;

        return permissions.Contains(permissionId.ToString());
    }

    //public async Task<bool> HasPermissionAsync(int userId, int permissionId)
    //{
    //    if (userId == 0) return false;
    //    return await _permissionRepository.DoesUserHavePermissionAsync(userId, permissionId);
    //}
}
