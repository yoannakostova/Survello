using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Survello.Services.Provider;
using Survello.Services.Provider.Contract;
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
            services.AddScoped<IFormServices, FormServices>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddSingleton<IEmailSender, EmailSender>();

            return services;
        }
    }
}
