﻿namespace CleanArch.Application.Products.Commands;

using CleanArch.Domain.Entities;
using MediatR;

public class ProductRemoveCommand : IRequest<Product>
{
    public int Id { get; set; }

    public ProductRemoveCommand(int id)
    {
        Id = id;
    }
}
