using FRD.Application;
using FRD.Domain;
using FRD.Infrustructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace FRD.Framework
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMyFramework(this IServiceCollection services, IConfiguration configuration)
        {
            // Example: Register services, options, etc.
            //services.AddScoped<IMyService, MyService>();
            var kk = configuration.GetConnectionString("FRDDatabase");
            services.AddDbContext<FRDDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FRDDatabase")));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddAutoMapper(typeof(mapperConfig));
            services.AddScoped<ICustomerUniquenessCheckerService, CustomerUniquenessCheckerService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(cfg =>
            {

                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ExceptionHandlingBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
                cfg.RegisterServicesFromAssembly(typeof(GetCustomerByEmailQuery).Assembly);
            });
           
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .Enrich.FromLogContext()
            .MinimumLevel.Debug()
            .CreateLogger();
            return services;
        }
    }
}
