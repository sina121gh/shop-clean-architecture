namespace Shop.Application.Features.Categories.Queries.GetAll
{
    public class GetAllUsersParameters : FilterAllEntitiesParameters
    {
        public bool? IsAdmin { get; set; }
    }
}
