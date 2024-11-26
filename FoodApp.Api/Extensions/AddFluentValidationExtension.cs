using System.Reflection;

namespace FoodApp.Api.Extensions;

public static class AddFluentValidationExtension
{
    public static IServiceCollection AddFluentValidationServices(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}
