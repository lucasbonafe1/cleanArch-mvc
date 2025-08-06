using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;

namespace CleanArch.Application.Products.Handlers;

public class GetProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductQuery, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<IEnumerable<Product>> Handle(GetProductQuery request,
        CancellationToken cancellationToken)
    {
        return await _productRepository.GetAllAsync();
    }
}
