namespace Shop.API.Extensions
{
    using ErrorOr;
    using global::Shop.API.Responses;
    using global::Shop.Application.DTOs;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    namespace Shop.API.Extensions
    {
        public static class ControllerExtensions
        {
            public static IActionResult ToActionResult<T>(
                this ControllerBase controller,
                ErrorOr<T> result,
                int? successStatusCode = null) // e.g 201, 204
            {
                if (result.IsError)
                {
                    var error = result.Errors.First();
                    var statusCode = error.Type switch
                    {
                        ErrorType.NotFound => StatusCodes.Status404NotFound,
                        ErrorType.Validation => StatusCodes.Status400BadRequest,
                        ErrorType.Conflict => StatusCodes.Status409Conflict,
                        ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    return controller.StatusCode(statusCode, new Response<T>
                    {
                        Succeeded = false,
                        Message = error.Description,
                        Errors = result.Errors.Select(e => e.Description).ToList()
                    });
                }

                var code = successStatusCode ?? StatusCodes.Status200OK;
                return controller.StatusCode(code, new Response<T>(result.Value, "Success"));
            }

            public static IActionResult ToActionResult<T>(
        this ControllerBase controller,
        ErrorOr<PagedResult<T>> result,
        int? successStatusCode = null)
            {
                if (result.IsError)
                {
                    var error = result.Errors.First();
                    var statusCode = error.Type switch
                    {
                        ErrorType.NotFound => StatusCodes.Status404NotFound,
                        ErrorType.Validation => StatusCodes.Status400BadRequest,
                        ErrorType.Conflict => StatusCodes.Status409Conflict,
                        ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    return controller.StatusCode(statusCode, new Response<T>
                    {
                        Succeeded = false,
                        Message = error.Description,
                        Errors = result.Errors.Select(e => e.Description).ToList()
                    });
                }

                var paged = result.Value;
                var code = successStatusCode ?? StatusCodes.Status200OK;

                var response = new PagedResponse<IEnumerable<T>>(
                    paged.Items,
                    paged.PageNumber,
                    paged.PageSize,
                    paged.TotalRecords
                );

                return controller.StatusCode(code, response);
            }
        }
    }

}
