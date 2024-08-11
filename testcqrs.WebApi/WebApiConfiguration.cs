using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testcqrs.DataAccess;
using testcqrs.DataAccess.Repositories;
using testcqrs.Domain.Contracts.Data;
using testcqrs.Domain.Contracts.Data.Repositories;
using testcqrs.Domain.Mapping;

namespace testcqrs.WebApi;
public class WebApiConfiguration
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddDbContextPool<DatabaseContext>(
            options =>
            {
                options.UseSnakeCaseNamingConvention();
                options.UseNpgsql("Host=localhost;Port=5432;Database=testcqrs;Username=postgres;Password=postgres;Pooling=true;",
                    b => b.MigrationsAssembly(assembly.FullName));
            }
        );
        services.AddControllers()
                .AddApplicationPart(assembly)
                .AddControllersAsServices();

        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(Assembly.Load(new AssemblyName("testcqrs.Application"))));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddAutoMapper(typeof(UserMapping));
    }
}