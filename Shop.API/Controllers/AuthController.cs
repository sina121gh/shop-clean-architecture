using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Extensions;
using Shop.Application.Features.Products.Queries.GetAllProducts;
using Shop.Application.Features.Users.Commands.Create;
using Shop.Application.Features.Users.Commands.Login;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserDto registerUserDto)
        {
            var result = await _mediator.Send(new RegisterUserCommand() { RegisterUserDto = registerUserDto });

            return this.ToActionResult(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserDto loginUserDto)
        {
            var result = await _mediator.Send(new LoginUserCommand() { Login = loginUserDto });
            return this.ToActionResult(result);
        }
    }
}
