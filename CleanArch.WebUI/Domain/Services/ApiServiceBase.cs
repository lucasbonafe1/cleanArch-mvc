namespace CleanArch.WebUI.Domain.Services;

public abstract class ApiServiceBase
{
    protected readonly HttpClient _httpClient;

    protected ApiServiceBase(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ApiClient");
    }
}