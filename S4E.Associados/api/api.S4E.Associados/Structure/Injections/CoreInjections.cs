using core.S4E.Associados.Contracts;
using core.S4E.Associados.Implementation;

namespace api.S4E.Associados.Structure.Injections
{
    public static class CoreInjections
    {
        public static IServiceCollection AddCoreInjections(this IServiceCollection services)
        {
            services.AddScoped<ICoreAssociado, CoreAssociado>();
            services.AddScoped<ICoreEmpresa, CoreEmpresa>();

            return services;
        }
    }
}