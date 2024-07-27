using api_sistema_recompensas.Services;

namespace api_sistema_recompensas.Config;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<UserService>();
        serviceCollection.AddScoped<TokenService>();
        serviceCollection.AddScoped<TaskService>();
        serviceCollection.AddScoped<RequestService>();
        serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();
    }
}
