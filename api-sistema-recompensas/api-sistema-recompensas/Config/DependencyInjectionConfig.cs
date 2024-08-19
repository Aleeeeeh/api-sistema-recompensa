using api_sistema_recompensas.Services;
using System.Text.Json.Serialization;

namespace api_sistema_recompensas.Config;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<UserService>();
        serviceCollection.AddScoped<TokenService>();
        serviceCollection.AddScoped<TaskService>();
        serviceCollection.AddScoped<RequestService>();
        serviceCollection.AddScoped<BalanceService>();
        serviceCollection.AddScoped<AccountService>();
        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        serviceCollection.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.WriteIndented = true;
            });

        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();
    }
}
