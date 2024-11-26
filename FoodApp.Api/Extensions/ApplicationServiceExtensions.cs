using System.Diagnostics;
using System.Reflection;

namespace FoodApp.Api.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();

        services.AddMediatRServices();

        services.AddSwaggerServices();

        services.AddFluentValidationServices();

        services.AddAuthServices(configuration);

        services.AddBackgroundJobsServices(configuration);

        services.AddDbContextServices(configuration);

        services.AddHttpContextAccessor();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<UserState>();
        services.AddScoped<RequestParameters>();
        services.AddScoped<ControllerParameters>();

        services.AddTransient<EmailSenderHelper>();

        services.AddSingleton<RabbitMQPublisherService>();
        services.AddSingleton<IHostedService, RabbitMQConsumerService>();

        return services;
    }
}