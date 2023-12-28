using api.S4E.Associados.Structure.Database;
using Microsoft.EntityFrameworkCore;
using repository.S4E.Associados.Context;

namespace api.S4E.Associados.Structure.Injections
{
    public static class DatabaseConf
    {
        public static IServiceCollection AddDatabaseConf(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString)
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            DbSeed.AddDatabaseWithSeed(connectionString);

            return services;
        }
    }
}
