using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService, IMapper mapper) : Controller
{
    private readonly IProductService _productService = productService;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetAllProducts()
    {
        var entities = await _productService.GetAllAsync();

        return Ok(entities);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> GetAllProducts(int id)
    {
        var entity = await _productService.GetByIdAsync(id);

        return Ok(entity);
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult> CreateAsync(ProductDTO product)
    {
        await _productService.CreateAsync(product);

        return Ok();
    }

    [HttpPut]
    [Route("")]
    public async Task<ActionResult> UpdateAsync(ProductDTO product)
    {
        await _productService.UpdateAsync(product);

        return Ok();
    }

    [HttpPut]
    [Route("hard-delete")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _productService.DeleteAsync(id);

        return Ok();
    }
}