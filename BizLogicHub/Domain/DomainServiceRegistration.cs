using Domain.Command;
using Domain.CommandHandler;
using Domain.Query;
using Domain.QueryHandler;
using Domain.Validators.CommandValidator;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Model.Dto;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class DomainServiceRegistration
    {
        public static IServiceCollection RegisterDomainExtensions(this IServiceCollection services)
        {

            services.AddScoped<IRequestHandler<GetUniversityQuery, QueryResponse<List<UniversityDto>>>, GetUniversityHandler>();
            services.AddScoped<IRequestHandler<GetMentorListQuery, QueryResponse<List<MentorDto>>>, GetMentorListHandler>();
            services.AddScoped<IRequestHandler<GetMentorDetailsQuery, QueryResponse<MentorDto>>, GetMentorDetailsQueryHandler>();

            services.AddScoped<IValidator<AddReviewCommand>, AddReviewCommandValidator>();
            services.AddScoped<IRequestHandler<AddReviewCommand, CommandResponse>, AddReviewCommandHandler>();
            return services;
        }
    }
}
