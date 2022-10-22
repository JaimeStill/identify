using Microsoft.Extensions.DependencyInjection;

namespace Identify.Services.Api;
public static class ServiceRegistrant
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddTransient<AdventurerService>();
        services.AddTransient<BotService>();        
    }    
}