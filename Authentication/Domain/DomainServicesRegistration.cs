using Domain.Command;
using Domain.CommandHandler;
using Domain.Validators.CommandValidators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Model.Response;

namespace Domain
{
    public static class DomainServicesRegistration
    {
        public static IServiceCollection RegisterDomainExtensions(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddScoped<IRequestHandler<RegisterCommand, CommandResponse>, RegisterCommandHandler>();

            return services;
        }
    }
}
