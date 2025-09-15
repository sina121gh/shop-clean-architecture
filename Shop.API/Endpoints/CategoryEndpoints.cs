using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Extensions;
using Shop.Application.Features.Categories.Queries.GetAll;
using Shop.Application.Parameters;

namespace Shop.API.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/categories");

            group.MapGet("/", GetAll);
        }

        private static async Task<IResult> GetAll(ISender mediator, [FromQuery] FilterAllEntitiesParameters filter, CancellationToken ct)
        {
            var result = await mediator.Send(new GetAllCategoriesQuery() { Parameters = filter }, ct);
            return result.ToMinimalApiResult();
        }
    }
}
