﻿using api.S4E.Associados.Structure.Database;
using Microsoft.EntityFrameworkCore;
using repository.S4E.Associados.Context;

namespace api.S4E.Associados.Structure.Injections
{
    public static class DatabaseConf
    {
        public static IServiceCollection AddDatabaseConf(this IServiceCollection services, ConfigurationManager configuration)
        {
            var canCreateDatabase = Convert.ToBoolean(configuration.GetSection("CanCreateDatabase").Value);
            var canCreateInnitialSeed = Convert.ToBoolean(configuration.GetSection("CanCreateInnitialSeed").Value);
            
            if(canCreateDatabase)
                DbSeed.AddDatabase("server=localhost;User ID=s4e;Password=s4e;TrustServerCertificate=True;");

            if (canCreateInnitialSeed)
                DbSeed.InitialSeed("server=localhost;User ID=s4e;Password=s4e;TrustServerCertificate=True;");

            var connectionString = configuration.GetConnectionString("SqlConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString)
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));



            return services;
        }
    }
}
