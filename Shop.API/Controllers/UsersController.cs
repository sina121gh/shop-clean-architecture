using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Extensions;
using Shop.Application.Features.Categories.Queries.GetAll;
using Shop.Application.Features.Products.Queries.GetAllProducts;
using Shop.Application.Features.Users.Commands.Create;
using Shop.Application.Features.Users.Commands.Delete;
using Shop.Application.Features.Users.Commands.UpdateProfile;
using Shop.Application.Features.Users.Queries.GetAll;
using Shop.Application.Features.Users.Queries.GetById;
using System.Security.Claims;

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

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfileAsync(int id, [FromBody] RegisterUserDto userDto)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (userId != id)
            {
                ErrorOr<Unit> unauthorizedResult = Error.Unauthorized();
                return this.ToActionResult(unauthorizedResult);
            }

            var result = await _mediator.Send(new UpdateProfileCommand() { Id = userId, UserDto = userDto });

            return this.ToActionResult(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountAsync(int id)
        {
            var userId = int.Parse(User.Identity?.Name);
            if (userId != id)
                return Unauthorized();

            var result = await _mediator.Send(new DeleteUserCommand() { Id = userId});

            return this.ToActionResult(result);
        }
    }
}
