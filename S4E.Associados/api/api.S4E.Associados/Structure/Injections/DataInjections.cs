namespace api.S4E.Associados.Structure.Injections
{
    using repository.S4E.Associados.Repositories;

    public static class DataInjections
    {
        public static IServiceCollection AddDataInjections(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IAssociadoRepository, AssociadoRepository>();
            services.AddScoped<IAssociadoEmpresaRepository, AssociadoEmpresaRepository>();

            return services;
        }
    }
}
