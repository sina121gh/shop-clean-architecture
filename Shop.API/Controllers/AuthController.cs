using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Extensions;
using Shop.Application.Features.Products.Queries.GetAllProducts;
using Shop.Application.Features.Users.Commands.Create;

namespace Shop.API.Controllers
{
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/register")]
        public async Task<IActionResult> RegisterAsync(RegisterUserDto registerUserDto)
        {
            var result = await _mediator.Send(new RegisterUserCommand() { RegisterUserDto = registerUserDto });

            return this.ToActionResult(result);
        }
    }
}
