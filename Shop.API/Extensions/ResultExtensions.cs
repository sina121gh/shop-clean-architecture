using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Responses;
using Shop.Application.DTOs;

namespace Shop.API.Extensions
{
    public static class ResultExtensions
    {
        // ===== Helperهای مشترک =====
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

        private static int MapErrorToStatusCode(Error error) =>
            error.Type switch
            {
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };

        private static Response<T> BuildErrorResponse<T>(ErrorOr<T> result)
        {
            var firstError = result.Errors.First();
            return new Response<T>
            {
                Succeeded = false,
                Message = GetMessageForError(firstError),
                Errors = result.Errors.Select(e => e.Description).ToList(),
                Data = default
            };
        }

        // ===== Controller Extensions =====
        public static IActionResult ToActionResult<T>(
            this ControllerBase controller,
            ErrorOr<T> result,
            int? successStatusCode = null)
        {
            if (result.IsError)
            {
                var response = BuildErrorResponse(result);
                return controller.StatusCode(MapErrorToStatusCode(result.Errors.First()), response);
            }

            var code = successStatusCode ?? StatusCodes.Status200OK;
            var successResponse = new Response<T>(
                result.Value,
                GetMessageForStatus(code)
            );

            return controller.StatusCode(code, successResponse);
        }

        public static IActionResult ToActionResult<T>(
            this ControllerBase controller,
            ErrorOr<PagedResult<T>> result,
            int? successStatusCode = null)
        {
            if (result.IsError)
            {
                var response = BuildErrorResponse(result);
                return controller.StatusCode(MapErrorToStatusCode(result.Errors.First()), response);
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

        // ===== Minimal API Extensions =====
        public static IResult ToMinimalApiResult<T>(
            this ErrorOr<T> result,
            int? successStatusCode = null)
        {
            if (result.IsError)
            {
                var response = BuildErrorResponse(result);
                return Results.Json(response, statusCode: MapErrorToStatusCode(result.Errors.First()));
            }

            var code = successStatusCode ?? StatusCodes.Status200OK;
            var successResponse = new Response<T>(
                result.Value,
                GetMessageForStatus(code)
            );

            return Results.Json(successResponse, statusCode: code);
        }

        public static IResult ToMinimalApiResult<T>(
            this ErrorOr<PagedResult<T>> result,
            int? successStatusCode = null)
        {
            if (result.IsError)
            {
                var response = BuildErrorResponse(result);
                return Results.Json(response, statusCode: MapErrorToStatusCode(result.Errors.First()));
            }

            var paged = result.Value;
            var code = successStatusCode ?? StatusCodes.Status200OK;
            var successResponse = new PagedResponse<IEnumerable<T>>(
                paged.Items,
                paged.PageNumber,
                paged.PageSize,
                paged.TotalRecords
            );

            return Results.Json(successResponse, statusCode: code);
        }
    }
}
