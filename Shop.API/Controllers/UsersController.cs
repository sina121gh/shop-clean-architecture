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
using Shop.Application.Security;
using System.Security.Claims;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUser;

        public UsersController(IMediator mediator,
            ICurrentUserService currentUser)
        {
            _mediator = mediator;
            _currentUser = currentUser;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync([FromQuery] GetAllUsersParameters filter)
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
            var result = await _mediator.Send(new UpdateProfileCommand() { Id = id, UserDto = userDto });

            return this.ToActionResult(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountAsync(int id)
        {

            var result = await _mediator.Send(new DeleteUserCommand() { Id = id });

            return this.ToActionResult(result);
        }
    }
}
