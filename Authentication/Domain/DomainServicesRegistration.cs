using Domain.Command;
using Domain.CommandHandler;
using Domain.Utils;
using Domain.Utils.Interfaces;
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
            services.AddScoped<IValidator<LoginCommand>, LoginCommandValidator>();

            services.AddScoped<IRequestHandler<RegisterCommand, CommandResponse>, RegisterCommandHandler>();
            services.AddScoped<IRequestHandler<LoginCommand, CommandResponse>, LoginCommnadHandler>();

            services.AddScoped<IPasswordHandler, PasswordHandler>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            
            return services;
        }
    }
}
