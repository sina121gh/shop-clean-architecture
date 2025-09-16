using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Extensions;
using Shop.Application.Features.Categories.Commands.Create;
using Shop.Application.Features.Categories.Commands.Delete;
using Shop.Application.Features.Categories.Commands.Update;
using Shop.Application.Features.Categories.Queries.GetAll;
using Shop.Application.Features.Categories.Queries.GetCategoryById;
using Shop.Application.Parameters;

namespace Shop.API.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/categories");
            
            group.MapGet("/", GetAllAsync);
            group.MapGet("/{id}", GetByIdAsync);

            group.MapPost("/", CreateCategoryAsync);

            group.MapPut("/{id}", UpdateCategoryAsync);

            group.MapDelete("/{id}", DeleteCategoryAsync);
        }

        private static async Task<IResult> GetAllAsync(ISender mediator, [AsParameters] FilterAllEntitiesParameters filter, CancellationToken ct)
        {
            var result = await mediator.Send(new GetAllCategoriesQuery() { Parameters = filter }, ct);
            return result.ToMinimalApiResult();
        }

        private static async Task<IResult> GetByIdAsync(ISender mediator, int id, CancellationToken ct)
        {
            var result = await mediator.Send(new GetCategoryByIdQuery() { Id = id }, ct);
            return result.ToMinimalApiResult();
        }

        private static async Task<IResult> CreateCategoryAsync(ISender mediator,
            [FromBody] CreateCategoryDto createCategoryDto, CancellationToken ct)
        {
            var result = await mediator.Send(new CreateCategoryCommand() { Category = createCategoryDto }, ct);
            return result.ToMinimalApiResult(201);
        }

        private static async Task<IResult> UpdateCategoryAsync(ISender mediator,
            int id, [FromBody] CreateCategoryDto createCategoryDto, CancellationToken ct)
        {
            var result = await mediator.Send(new UpdateCategoryCommand() { Id = id, Category = createCategoryDto }, ct);
            return result.ToMinimalApiResult(204);
        }

        private static async Task<IResult> DeleteCategoryAsync(ISender mediator,
            int id, CancellationToken ct)
        {
            var result = await mediator.Send(new DeleteCategoryCommand() { Id = id }, ct);
            return result.ToMinimalApiResult(204);
        }
    }
}
