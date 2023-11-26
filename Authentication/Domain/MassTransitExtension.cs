using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class MassTransitExtension
    {
        public static IServiceCollection AddMassTransitExtension(this IServiceCollection services) 
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "WebService"))
            .AddJsonFile("appsettings.json")
            .Build();

            services.AddMassTransit(x =>
            {
                x.AddDelayedMessageScheduler();
                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMq"));
                    cfg.UseDelayedMessageScheduler();
                    cfg.ServiceInstance(instance =>
                    {
                        instance.ConfigureJobServiceEndpoints();
                        instance.ConfigureEndpoints(ctx, new KebabCaseEndpointNameFormatter("dev", false));
                    });
                });
            });
            return services;
        }
    }
}
