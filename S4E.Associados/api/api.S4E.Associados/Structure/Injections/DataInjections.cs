namespace api.S4E.Associados.Structure.Injections
{
    using repository.S4E.Associados.Repositories;
    using repository.S4E.Empresas.Repositories;

    public static class DataInjections
    {
        public static IServiceCollection AddDataInjections(this IServiceCollection services)
        {
            services.AddScoped<IAssociadoRepository, AssociadoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            return services;
        }
    }
}
