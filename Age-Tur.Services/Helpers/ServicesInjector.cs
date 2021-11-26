using Age_Tur.Services.Base;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Age_Tur.Services.Helpers
{
    public static class ServicesInjector
    {
        public static IServiceCollection AddServices(this IServiceCollection services, Assembly servicesAssembly)
        {
            var concreteServices = servicesAssembly.GetExportedTypes()
                                 .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(Service).IsAssignableFrom(c));

            foreach (var serviceType in concreteServices)
            {
                services.AddScoped(serviceType);
            }

            return services;
        }
    }
}
