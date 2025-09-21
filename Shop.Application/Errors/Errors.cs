// Application/Common/Errors/Errors.Authorization.cs
using ErrorOr;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class Authorization
    {
        public static readonly Error Unauthorized = Error.Unauthorized(
            description: "شما لاگین نیستید.");

        public static Error Forbidden(string permission) => Error.Forbidden(
            description: $"شما دسترسی لازم برای {permission} را ندارید.");

        public static readonly Error NotOwner = Error.Forbidden(
            description: "شما مالک این داده نیستید.");
    }

    public static class Validation
    {
        public static Error NotFound(string entityName, int id) =>
            Error.NotFound(description: $"{entityName} با آیدی {id} یافت نشد");


        public static Error NotFound() => Error.NotFound(
            description: "داده مورد نظر یافت نشد");

        public static readonly Error Unexpected =
            Error.Unexpected(description: "مشکلی به وجود آمد");
    }
}
