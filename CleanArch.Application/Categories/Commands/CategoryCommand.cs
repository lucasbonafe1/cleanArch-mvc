using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Categories.Commands;

public abstract class CategoryCommand : IRequest<Category> 
{
    public string Name { get; protected set; } = string.Empty;
}
