using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService categoryService, IMapper mapper) : Controller
{
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetAllProducts()
    {
        var entities = await _categoryService.GetAllAsync();

        return Ok(entities);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var entity = await _categoryService.GetByIdAsync(id);

        return Ok(entity);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> CreateAsync(CategoryDTO category)
    {
        await _categoryService.CreateAsync(category);

        return Ok();
    }

    [HttpPut]
    [Route("")]
    public async Task<ActionResult> UpdateAsync(CategoryDTO categorydto)
    {
        await _categoryService.UpdateAsync(categorydto);

        return Ok();
    }

    [HttpPut]
    [Route("hard-delete")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _categoryService.DeleteAsync(id);

        return Ok();
    }
}