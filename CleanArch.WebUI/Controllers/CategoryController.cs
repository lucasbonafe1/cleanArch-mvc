using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers;

[Authorize]
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

    [HttpGet()]
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> CreateAsync(CategoryDTO category)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    [HttpGet()]
    public async Task<ActionResult> Edit(int id)
    {
        var entity = await _categoryService.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        return View(entity);
    }

    [HttpPost()]
    public async Task<ActionResult> Edit(CategoryDTO category)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _categoryService.UpdateAsync(category);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }

    [HttpGet()]
    public async Task<ActionResult> Delete(CategoryDTO categoryDTO)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _categoryService.DeleteAsync(categoryDTO.Id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(categoryDTO);
    }

    [HttpPost(), ActionName(nameof(Delete))]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        await _categoryService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var entity = await _categoryService.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        return View(entity);
    }
}
