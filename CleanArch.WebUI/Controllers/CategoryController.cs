using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers;

public class CategoryController(ICategoryService categoryService) : Controller
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetAllProducts()
    {
        var entities = await _categoryService.GetAllAsync();

        return Ok(entities);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetAllProducts(int? id)
    {
        var entity = await _categoryService.GetByIdAsync(id);

        return Ok(entity);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> CreateAsync(Category category)
    {
        var entity = await _categoryService.CreateAsync(category);

        return Ok(entity);
    }

    [HttpPut]
    [Route("")]
    public async Task<ActionResult> UpdateAsync(int id)
    {
        var entity = await _categoryService.UpdateAsync(id);

        return Ok(entity);
    }

    [HttpPut]
    [Route("hard-delete")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var entity = await _categoryService.DeleteAsync(id);

        return Ok(entity);
    }
}
