namespace FoodApp.Api.Extensions;

public static class AddMediatRServicesExtension
{
    public static IServiceCollection AddMediatRServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

        return services;
    }
}