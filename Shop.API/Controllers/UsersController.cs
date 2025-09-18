using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Extensions;
using Shop.Application.Features.Categories.Queries.GetAll;
using Shop.Application.Features.Products.Queries.GetAllProducts;
using Shop.Application.Features.Users.Queries.GetAll;
using Shop.Application.Features.Users.Queries.GetById;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync(GetAllUsersParameters filter)
        {
            var result = await _mediator.Send(new GetAllUsersQuery() { Parameters = filter });

            return this.ToActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery() { Id = id });

            return this.ToActionResult(result);
        }
    }
}
