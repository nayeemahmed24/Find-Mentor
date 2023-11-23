using Microsoft.Extensions.DependencyInjection;
using Model.Dto;
using Model.Response;
using Service.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceRegistration
    {
        public static IServiceCollection ServiceRegistrationExtension(this IServiceCollection services)
        {

            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<IMentorService, MentorService>();
            services.AddScoped<IReviewService, ReviewService>();
            return services;
        }
    }
}
