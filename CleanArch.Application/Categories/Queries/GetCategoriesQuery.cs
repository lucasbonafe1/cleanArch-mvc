using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Categories.Queries;

public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
{}
