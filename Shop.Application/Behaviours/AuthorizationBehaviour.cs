using Application.Common.Errors;
using ErrorOr;
using MediatR;
using Shop.Application.Security;

public class AuthorizationBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
    where TResponse : IErrorOr
{
    private readonly ICurrentUserService _currentUser;

    public AuthorizationBehaviour(ICurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // Login Check
        if (!_currentUser.IsAuthenticated)
        {
            return (dynamic)Errors.Authorization.Unauthorized;
        }

        // Permission Check
        if (request is IRequirePermission requirePermission)
        {
            if (!_currentUser.HasPermission(requirePermission.Permission))
            {
                return (dynamic)Errors.Authorization.Forbidden(requirePermission.Permission);
            }
        }

        // Ownership Check
        if (request is IRequireOwnership requireOwnership)
        {
            if (_currentUser.UserId != requireOwnership.ResourceOwnerId)
            {
                return (dynamic)Errors.Authorization.NotOwner;
            }
        }

        return await next();
    }
}
