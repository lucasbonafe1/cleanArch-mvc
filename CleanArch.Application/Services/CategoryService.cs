using AutoMapper;
using CleanArch.Application.Categories.Commands;
using CleanArch.Application.Categories.Queries;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using MediatR;

namespace CleanArch.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CategoryService(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
        var categoriesQuery = new GetCategoriesQuery();

        var result = await _mediator.Send(categoriesQuery);

        return _mapper.Map<IEnumerable<CategoryDTO>>(result);
    }

    public async Task<CategoryDTO?> GetByIdAsync(int id)
    {
        var categoryByIdQuery = new GetCategoryByIdQuery(id);

        var result = await _mediator.Send(categoryByIdQuery);

        return _mapper.Map<CategoryDTO>(result);
    }

    public async Task CreateAsync(CategoryDTO categoryDto)
    {
        var categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDto);
        await _mediator.Send(categoryCreateCommand);
    }

    public async Task<CategoryDTO> UpdateAsync(int id)
    {
        var categoryByIdQuery = new GetCategoryByIdQuery(id);

        if (categoryByIdQuery == null)
            throw new Exception($"Entity could not be loaded.");

        var categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryByIdQuery);
        await _mediator.Send(categoryUpdateCommand);

        return _mapper.Map<CategoryDTO>(categoryUpdateCommand);
    }

    public async Task DeleteAsync(int id)
    {
        var categoryRemoveCommand = new CategoryRemoveCommand(id);
        if (categoryRemoveCommand == null)
            throw new Exception($"Entity could not be loaded.");

        await _mediator.Send(categoryRemoveCommand);
    }
}
