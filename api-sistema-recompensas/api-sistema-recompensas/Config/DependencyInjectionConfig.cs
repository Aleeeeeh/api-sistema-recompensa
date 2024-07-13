namespace api_sistema_recompensas.Config;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddControllers();
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();
    }
}
