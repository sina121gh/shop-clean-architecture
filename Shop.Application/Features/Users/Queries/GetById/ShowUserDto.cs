namespace Shop.Application.Features.Users.Queries.GetById
{
    public record ShowUserDto
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
