using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Responses;
using Shop.Application.DTOs;

namespace Shop.API.Extensions
{
    public static class ControllerExtensions
    {
        private static string GetMessageForError(Error error) =>
            error.Type switch
            {
                ErrorType.Validation => "Validation error(s) occurred.",
                ErrorType.NotFound => "Resource not found.",
                ErrorType.Conflict => "Conflict occurred.",
                ErrorType.Unauthorized => "Unauthorized.",
                _ => error.Description
            };

        private static string GetMessageForStatus(int statusCode) =>
            statusCode switch
            {
                200 => "Success",
                201 => "Created",
                204 => "No Content",
                400 => "Bad Request",
                401 => "Unauthorized",
                403 => "Forbidden",
                404 => "Not Found",
                409 => "Conflict",
                500 => "Internal Server Error",
                _ => "Unknown status"
            };

       // Normal Response
        public static IActionResult ToActionResult<T>(
            this ControllerBase controller,
            ErrorOr<T> result,
            int? successStatusCode = null)
        {
            if (result.IsError)
            {
                var firstError = result.Errors.First();

                var response = new Response<T>
                {
                    Succeeded = false,
                    Message = GetMessageForError(firstError),
                    Errors = result.Errors.Select(e => e.Description).ToList(),
                    Data = default
                };

                var statusCode = firstError.Type switch
                {
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                    ErrorType.Validation => StatusCodes.Status400BadRequest,
                    ErrorType.Conflict => StatusCodes.Status409Conflict,
                    ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };

                return controller.StatusCode(statusCode, response);
            }

            var code = successStatusCode ?? StatusCodes.Status200OK;
            var successResponse = new Response<T>(
                result.Value,
                GetMessageForStatus(code)
            );

            return controller.StatusCode(code, successResponse);
        }

        // Paged Response
        public static IActionResult ToActionResult<T>(
            this ControllerBase controller,
            ErrorOr<PagedResult<T>> result,
            int? successStatusCode = null)
        {
            if (result.IsError)
            {
                var firstError = result.Errors.First();

                var response = new Response<T>
                {
                    Succeeded = false,
                    Message = GetMessageForError(firstError),
                    Errors = result.Errors.Select(e => e.Description).ToList(),
                    Data = default
                };

                var statusCode = firstError.Type switch
                {
                    ErrorType.NotFound => StatusCodes.Status404NotFound,
                    ErrorType.Validation => StatusCodes.Status400BadRequest,
                    ErrorType.Conflict => StatusCodes.Status409Conflict,
                    ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };

                return controller.StatusCode(statusCode, response);
            }

            var paged = result.Value;
            var code = successStatusCode ?? StatusCodes.Status200OK;

            var successResponse = new PagedResponse<IEnumerable<T>>(
                paged.Items,
                paged.PageNumber,
                paged.PageSize,
                paged.TotalRecords
            );

            return controller.StatusCode(code, successResponse);
        }
    }
}
