using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries;

public class GetProductQuery : IRequest<IEnumerable<Product>>
{}
