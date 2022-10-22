using Microsoft.Extensions.DependencyInjection;

namespace Identify.Services.Api;
public static class ServiceRegistrant
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddTransient<AdventurerAccessoryService>();
        services.AddTransient<AdventurerEyeService>();
        services.AddTransient<AdventurerEyebrowService>();
        services.AddTransient<AdventurerHairService>();
        services.AddTransient<AdventurerMouthService>();
        services.AddTransient<AdventurerService>();
        services.AddTransient<BotColorService>();
        services.AddTransient<BotService>();        
    }    
}