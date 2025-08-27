namespace UnityConverter.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<Domain.Interfaces.IUnitConverter, Domain.Services.UnitConverterService>();
            return services;
        }
    }
}
