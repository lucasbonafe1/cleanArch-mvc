using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebUI.Controllers;

public class ProductController(IProductService productService, IMapper mapper) : Controller
{
    private readonly IProductService _productService = productService;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetAllProducts()
    {
        var entities = await _productService.GetAllAsync();

        var products = _mapper.Map<IEnumerable<ProductResponseModel>>(entities);

        return Ok(products);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetAllProducts(int? id)
    {
        var entity = await _productService.GetByIdAsync(id);

        var product = _mapper.Map<ProductResponseModel>(entity);

        return Ok(product);
    }

    [HttpGet]
    [Route("product-and-categories/{id}")]
    public async Task<ActionResult> GetProductWithCategoryAsync(int? id)
    {
        var entity = await _productService.GetProductCategoryAsync(id);

        var product = _mapper.Map<ProductResponseModel>(entity);

        return Ok(product);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> CreateAsync(Product product)
    {
        var entity = await _productService.CreateAsync(product);

        var productMapped = _mapper.Map<ProductResponseModel>(entity);

        return Ok(productMapped);
    }

    [HttpPut]
    [Route("")]
    public async Task<ActionResult> UpdateAsync(int id)
    {
        var entity = await _productService.UpdateAsync(id);

        var productMapped = _mapper.Map<ProductResponseModel>(entity);

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
