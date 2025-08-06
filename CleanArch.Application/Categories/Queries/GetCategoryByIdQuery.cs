using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Categories.Queries;

public class GetCategoryByIdQuery : IRequest<Category>
{
    public int Id { get; private set; }

    public GetCategoryByIdQuery(int id)
    {
        Id = id;
    }
}
