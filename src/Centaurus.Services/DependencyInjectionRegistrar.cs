namespace Centaurus.Services;

using Microsoft.AspNetCore.Builder;

public static class DependencyInjectionRegistrar
{
    public static WebApplicationBuilder AddCentaurusServices(this WebApplicationBuilder webApplicationBuilder)
    {
        
        
        return webApplicationBuilder;
    }
}