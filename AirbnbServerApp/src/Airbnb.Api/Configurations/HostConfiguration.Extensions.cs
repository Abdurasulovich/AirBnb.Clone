using Airbnb.Application.Common.Services.Interfaces;
using Airbnb.Infrastructure.Common.Caching.Brokers;
using Airbnb.Infrastructure.Services;
using Airbnb.Infrastructure.Settings;
using Airbnb.Persistence.Caching.Brokers.Interfaces;
using Airbnb.Persistence.DataContexts;
using Airbnb.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Airbnb.Application.Common.Serializer;
using Airbnb.Infrastructure.Common.Serializer;
using Airbnb.Persistence.Repositories.Interfaces;

namespace Airbnb.Api.Configurations
{
    // This class contains extension methods to configure various services for the web application.
    public static partial class HostConfiguration
    {
        // Collection of assemblies used for configuration
        private static readonly ICollection<Assembly> Assemblies;

        // Static constructor to initialize the assemblies collection
        static HostConfiguration()
        {
            // Populate the Assemblies collection with referenced assemblies
            Assemblies = typeof(HostConfiguration).Assembly.GetReferencedAssemblies().Select(Assembly.Load)
                .ToList();

            // Add the current assembly to the Assemblies collection
            Assemblies.Add(typeof(HostConfiguration).Assembly);
        }

        // Extension method to configure mapping using AutoMapper
        private static WebApplicationBuilder AddMapping(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(Assemblies);
            return builder;
        }

        // Extension method to configure caching using Redis and cache settings
        private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
        {
            // Register cache settings
            builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));

            // Configure Redis cache
            builder.Services.AddStackExchangeRedisCache(
                options =>
                {
                    options.Configuration = builder.Configuration.GetConnectionString("RedisConnectionString");
                    options.InstanceName = "Caching.Airbnb";
                }
            );

            // Register Redis cache broker
            builder.Services.AddSingleton<ICacheBroker, RedisDistributedCacheBroker>();

            return builder;
        }

        // Extension method to configure Identity infrastructure, including DbContext, repositories, and services
        private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
        {
            // Configure API settings
            builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));

            // Add DbContext for Airbnb
            builder.Services.AddDbContext<AirbnbDbContext>(
                options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Register repositories and services
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped(typeof(ILocationCategoryRepository), typeof(LocationCategoryRepository));
            builder.Services.AddScoped<ILocationService, LocationService>();
            builder.Services.AddScoped(typeof(ILocationCategoryService), typeof(LocationCategoryService));
            builder.Services.AddScoped<IUrlService, UrlService>();
            builder.Services.AddSingleton<IJsonSerializationSettingsProvider,  JsonSerializationSettingsProvider>();
            

            // Register Redis cache broker
            builder.Services.AddScoped<ICacheBroker, RedisDistributedCacheBroker>();

            return builder;
        }

        // Extension method to configure Cross-Origin Resource Sharing (CORS) policies
        private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(
                options =>
                {
                    options.AddDefaultPolicy(policyBuilder =>
                    {
                        policyBuilder.AllowAnyHeader();
                        policyBuilder.AllowAnyMethod();
                        policyBuilder.AllowAnyOrigin();
                    });
                });

            return builder;
        }

        // Extension method to configure endpoints, controllers, and JSON serialization
        private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
        {
            builder.Services.AddRouting(options => options.LowercaseUrls = true);
            builder.Services.AddControllers().AddNewtonsoftJson();

            return builder;
        }

        // Extension method to add development tools like Swagger for API documentation
        private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        // Extension method to map controllers
        private static WebApplication UseExposers(this WebApplication app)
        {
            app.MapControllers();
            return app;
        }

        // Extension method to seed data asynchronously

        // Extension method to use development tools like Swagger UI
        private static WebApplication UseDevTools(this WebApplication app)
        {
            app.UseSwagger();
            app.UseStaticFiles();
            app.UseSwaggerUI();

            return app;
        }
    }
}
