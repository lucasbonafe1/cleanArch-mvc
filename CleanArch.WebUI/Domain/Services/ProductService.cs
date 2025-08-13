using CleanArch.Application.DTOs;
using CleanArch.WebUI.Domain.Services.Interfaces;

namespace CleanArch.WebUI.Domain.Services;

public class ProductService(IHttpClientFactory httpClientFactory) : ApiServiceBase(httpClientFactory), IProductService
{
    private readonly string baseUrl = "Product/";

    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        var resultado = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDTO>>(baseUrl);

        return resultado!;
    }

    public async Task<ProductDTO?> GetByIdAsync(int id)
    {
        var resultado = await _httpClient.GetFromJsonAsync<ProductDTO>($"{baseUrl}{id}");

        return resultado;
    }

    public async Task CreateAsync(ProductDTO entity)
    {
        var response = await _httpClient.PostAsJsonAsync(baseUrl, entity);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(ProductDTO entity)
    {
        var response = await _httpClient.PutAsJsonAsync($"{baseUrl}{entity.Id}", entity);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"{baseUrl}{id}");
        response.EnsureSuccessStatusCode();
    }
}