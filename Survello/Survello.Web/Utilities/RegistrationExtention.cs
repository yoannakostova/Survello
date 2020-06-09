using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using NToastNotify;
using Survello.Services.Provider;
using Survello.Services.Provider.Contract;
using Survello.Services.Services;
using Survello.Services.Services.Contracts;

namespace Survello.Web.Utilities
{
    public static class RegistrationExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
           

            return services;
        }
    }
}
