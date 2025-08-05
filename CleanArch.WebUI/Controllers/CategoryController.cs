using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers;

public class CategoryController(ICategoryService categoryService, IMapper mapper) : Controller
{
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var entities = await _categoryService.GetAllAsync();

        var categories = _mapper.Map<IEnumerable<CategoryResponseModel>>(entities);

        return View(categories);
    }

    //[HttpGet]
    //[Route("{id}")]
    //public async Task<ActionResult> GetByIdAsync(int? id)
    //{
    //    var category = await _categoryService.GetByIdAsync(id);

    //    var categoryMapped = _mapper.Map<CategoryResponseModel>(category);

    //    return Ok(categoryMapped);
    //}

    //[HttpPost]
    //[Route("")]
    //public async Task<ActionResult> CreateAsync(Category category)
    //{
    //    var entity = await _categoryService.CreateAsync(category);

    //    return Ok(entity);
    //}

    //[HttpPut]
    //[Route("")]
    //public async Task<ActionResult> UpdateAsync(int id)
    //{
    //    var entity = await _categoryService.UpdateAsync(id);

    //    return Ok(entity);
    //}

    //[HttpPut]
    //[Route("hard-delete")]
    //public async Task<ActionResult> DeleteAsync(int id)
    //{
    //    var entity = await _categoryService.DeleteAsync(id);

    //    var category = _mapper.Map<CategoryResponseModel>(entity);

    //    return Ok(category);
    //}
}
