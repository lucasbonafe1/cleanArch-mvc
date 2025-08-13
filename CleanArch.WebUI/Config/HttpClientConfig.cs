namespace CleanArch.WebUI.Config;

public static class HttpCLientConfig 
{ 
    public static void AddHttpClientConfig(this IServiceCollection services, IConfiguration configuartion)
    {
        var urlBase = configuartion?.GetSection("ApiBase")?.Value;
        services
            .AddHttpClient("ApiClient", h => h.BaseAddress = new Uri(urlBase!));
    }
}
