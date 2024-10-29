using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ExamenBackend.Infrastructure.Persistence;
using AppUser = ExamenBackend.Domain.Models.User;
using Microsoft.AspNetCore.Identity;
using ExamenBackend.Domain.Repositories;
using ExamenBackend.Infrastructure.Repositories;

namespace ExamenBackend.Infrastructure.Extensions;

public static class ServicesExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ExamenDb");

        services.AddDbContext<GlobalDbContext>(
            options => options
                .UseNpgsql(connectionString)
                .EnableSensitiveDataLogging()
        );

        services
            .AddIdentityApiEndpoints<AppUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<GlobalDbContext>();

        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
        });

        services.AddScoped<IUserRepository, UserRepository>();

    }
}
