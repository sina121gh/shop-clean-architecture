using Application.Common.Errors;
using Shop.Application.Security;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    where TResponse : IErrorOr
{
    private readonly ICurrentUserService _currentUser;

    public AuthorizationBehaviour(ICurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        // Authentication Check
        if (request is IRequireAuthorization)
            if (!_currentUser.IsAuthenticated)
                return (dynamic)Errors.Authorization.Unauthorized;

        if (request is IRequirePermission permReq && request is IRequireOwnership ownReq)
        {
            var isOwner = _currentUser.UserId == ownReq.ResourceOwnerId;
            var hasPermission = await _currentUser.HasPermissionAsync(permReq.Permission);

            if (!isOwner && !hasPermission)
                return (dynamic)Errors.Authorization.Forbidden(permReq.Permission);
        }
        else if (request is IRequirePermission permOnly)
        {
            if (!await _currentUser.HasPermissionAsync(permOnly.Permission))
                return (dynamic)Errors.Authorization.Forbidden(permOnly.Permission);
        }
        else if (request is IRequireOwnership ownOnly)
        {
            if (_currentUser.UserId != ownOnly.ResourceOwnerId)
                return (dynamic)Errors.Authorization.NotOwner;
        }

        return await next();
    }
}
