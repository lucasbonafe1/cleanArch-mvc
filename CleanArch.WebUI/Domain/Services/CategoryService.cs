using CleanArch.Application.DTOs;
using CleanArch.WebUI.Domain.Services.Interfaces;
using System.Net.Http;

namespace CleanArch.WebUI.Domain.Services;

public class CategoryService(IHttpClientFactory httpClientFactory) : ApiServiceBase(httpClientFactory), ICategoryService
{
    private readonly string baseUrl = "Category/";

    public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
    {
        var resultado = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryDTO>>(baseUrl);

        return resultado!;
    }

    public async Task<CategoryDTO?> GetByIdAsync(int id)
    {
        var resultado = await _httpClient.GetFromJsonAsync<CategoryDTO>($"{baseUrl}{id}");

        return resultado;
    }

    public async Task CreateAsync(CategoryDTO entity)
    {
        var response = await _httpClient.PostAsJsonAsync(baseUrl, entity);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(CategoryDTO entity)
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