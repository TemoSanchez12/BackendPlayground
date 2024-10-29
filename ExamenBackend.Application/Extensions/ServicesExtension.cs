using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ExamenBackend.Application.Extensions;

public static class ServicesApplicationExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServicesApplicationExtension).Assembly;

        services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));
        services.AddValidatorsFromAssembly(applicationAssembly);
    }
}
