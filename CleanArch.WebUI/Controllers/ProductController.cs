using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArch.WebUI.Controllers;

public class ProductController(IProductService productService, IMapper mapper, ICategoryService categoryService, IWebHostEnvironment environment) : Controller
{
    private readonly IProductService _productService = productService;
    private readonly ICategoryService _categoryService = categoryService;
    private readonly IWebHostEnvironment _environment = environment;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        var entities = await _productService.GetAllAsync();

        var products = _mapper.Map<IEnumerable<ProductResponseModel>>(entities);

        return View(products);
    }

    [HttpGet()]
    public async Task<ActionResult> Create()
    {
        ViewBag.CategoryId =
            new SelectList(await _categoryService.GetAllAsync(), "Id", "Name");
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(ProductDTO productDTO)
    {
        if (ModelState.IsValid)
        {
            await _productService.CreateAsync(productDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(productDTO);
    }

    [HttpGet()]
    public async Task<ActionResult> Edit(int id)
    {
        var productDto = await _productService.GetByIdAsync(id);

        ViewBag.CategoryId =
            new SelectList(await _categoryService.GetAllAsync(), "Id", "Name", productDto.CategoryId);

        return View(productDto);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(ProductDTO productDTO)
    {
        if (ModelState.IsValid)
        {
            await _productService.UpdateAsync(productDTO);
            return RedirectToAction(nameof(Index));
        }

        return View(productDTO);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet()]
    public async Task<ActionResult> Delete(ProductDTO productDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _productService.DeleteAsync(productDto.Id);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        return View(productDto);
    }

    [HttpPost(), ActionName(nameof(Delete))]
    public async Task<ActionResult> DeleteConfirmed(int id)
    {
        await _productService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var entity = await _productService.GetByIdAsync(id);

        if (entity == null)
            return NotFound();

        var wwwroot = _environment.WebRootPath;
        var image = Path.Combine(wwwroot, "images\\" + entity.Image);
        var exists = System.IO.File.Exists(image);
        ViewBag.ImageExist = exists;

        return View(entity);
    }
}
