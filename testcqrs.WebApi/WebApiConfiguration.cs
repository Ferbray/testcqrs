using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using testcqrs.ModuleName.Data;
using testcqrs.ModuleName.Contracts.Data;
using testcqrs.ModuleName.Contracts.Mapping;
using testcqrs.ModuleName.Entities;

namespace testcqrs.ModuleName.Configurations;

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

        services.AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ICommonRepository<UserEntity>, CommonRepository<UserEntity>>();

        services.AddAutoMapper(typeof(UserMapping));
    }
}