using UnityConverter.Application.Interface;
using UnityConverter.Application.Service;
using UnityConverter.Domain.Interfaces;
using UnityConverter.Domain.Services;

namespace UnityConverter.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitConverter, UnitConverterService>();
            services.AddScoped<IConversionService, ConversionService>();
            return services;
        }
    }
}
