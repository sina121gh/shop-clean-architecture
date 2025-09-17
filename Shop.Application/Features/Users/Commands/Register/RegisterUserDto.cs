namespace Shop.Application.Features.Users.Commands.Create
{
    public record RegisterUserDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
