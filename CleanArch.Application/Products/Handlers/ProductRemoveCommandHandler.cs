using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers;

public class ProductRemoveCommandHandler(IProductRepository productRepository) : IRequestHandler<ProductRemoveCommand, Product>
{
    private readonly IProductRepository _productRepository = productRepository ?? throw new
            ArgumentNullException(nameof(productRepository));

    public async Task<Product> Handle(ProductRemoveCommand request,
        CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product == null)
        {
            throw new ApplicationException($"Entity could not be found.");
        }
        else
        {
            var result = await _productRepository.DeleteAsync(product);
            return result;
        }
    }
}
