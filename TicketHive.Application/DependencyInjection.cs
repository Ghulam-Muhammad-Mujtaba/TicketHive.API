using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TicketHive.Application.Behaviors;

namespace TicketHive.Application
{
    // This class is responsible for registering application services
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            // 1. Register AutoMapper
            services.AddAutoMapper(assembly);

            // 2. Register MediatR
            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(assembly);

                // Register the Validation Behavior (The Guard)
                // This will now run for every command in this assembly
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            // 3. Register FluentValidation
            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
