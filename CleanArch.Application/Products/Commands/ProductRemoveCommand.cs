namespace CleanArch.Application.Products.Commands;

using CleanArch.Domain.Entities;
using MediatR;

public abstract class ProductRemoveCommand : IRequest<Product>
{
    public int Id { get; set; }

    protected ProductRemoveCommand(int id)
    {
        Id = id;
    }
}
