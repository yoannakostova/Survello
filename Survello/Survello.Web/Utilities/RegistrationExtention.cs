using Microsoft.Extensions.DependencyInjection;
using Survello.Services.Services;
using Survello.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survello.Web.Utilities
{
    public static class RegistrationExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITextQuestionServices, TextQuestionServices>();


            return services;
        }
    }
}
