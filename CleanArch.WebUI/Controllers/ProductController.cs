using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers;

public class ProductController(IProductService productService) : Controller
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetAllProducts()
    {
        var entities = await _productService.GetAllAsync();

        return Ok(entities);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetAllProducts(int? id)
    {
        var entity = await _productService.GetByIdAsync(id);

        return Ok(entity);
    }

    [HttpGet]
    [Route("product-and-categories/{id}")]
    public async Task<ActionResult> GetProductCategoryAsync(int? id)
    {
        var entity = await _productService.GetProductCategoryAsync(id);

        return Ok(entity);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> CreateAsync(Product product)
    {
        var entity = await _productService.CreateAsync(product);

        return Ok(entity);
    }

    [HttpPut]
    [Route("")]
    public async Task<ActionResult> UpdateAsync(int id)
    {
        var entity = await _productService.UpdateAsync(id);

        return Ok(entity);
    }

    [HttpPut]
    [Route("hard-delete")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var entity = await _productService.DeleteAsync(id);

        return Ok(entity);
    }
}
