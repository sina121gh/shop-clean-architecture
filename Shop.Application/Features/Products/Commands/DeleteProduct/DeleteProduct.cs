namespace Shop.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ErrorOr<Unit>>
    {
        public int Id { get; set; }
    }

    class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ErrorOr<Unit>>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ErrorOr<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            _productRepository.Delete(product);

            try
            {
                await _productRepository.SaveChangesAsync();
                return Unit.Value;
            }
            catch (Exception)
            {
                return Error.Unexpected();
            }
        }
    }
}
