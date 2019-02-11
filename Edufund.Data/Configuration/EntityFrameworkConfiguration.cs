using Edufund.Data.Configuration.Helpers;
using Edufund.Data.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Edufund.Data.Configuration;
using Edufund.Data.Identity;

namespace Edufund.Data.Configuration
{
    public static class EntityFrameworkConfiguration
    {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services, IConfigurationRoot configuration)
        {
            string connectionString = configuration.GetConnectionString(Constants.DefaultConnection);

            // Database connection settings
            var connectionOptions = services.BuildServiceProvider().GetRequiredService<IOptions<ConnectionSettings>>();

            RegisterDatabaseType(services, connectionOptions);

            var databaseTypeInstance = services.BuildServiceProvider().GetRequiredService<IDatabaseType>();

            databaseTypeInstance.EnableDatabase(services, connectionOptions);

            // Entity framework configuration
            services.AddDbContext<EduFundContext>(options =>
                databaseTypeInstance.GetContextBuilder(options, connectionOptions, connectionString));



            services.AddScoped<IDbContext, EduFundContext>();
        }

        /// <summary>
        ///  Configures the assembly where migrations are maintained for this context.
        ///  <see href="https://docs.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/index" /> for migrations
        ///  <see href="https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet"/> for command line tools
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <typeparam name="TExtension"></typeparam>
        /// <param name="builder"></param>
        /// <returns>Migrations configured builder</returns>
        public static TBuilder GetMigrationInformation<TBuilder, TExtension>(RelationalDbContextOptionsBuilder<TBuilder, TExtension> builder)
             where TBuilder : RelationalDbContextOptionsBuilder<TBuilder, TExtension>
            where TExtension : RelationalOptionsExtension, new()
        {

            return builder.MigrationsAssembly(typeof(EduFundContext).Assembly.GetName().Name);
        }

        /// <summary>
        /// Inject database settings instance based on the connection string
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionOptions"></param>
        private static void RegisterDatabaseType(IServiceCollection services, IOptions<ConnectionSettings> connectionOptions)
        {
            var databaseInterfaceType = typeof(IDatabaseType);
            var instanceType = connectionOptions.Value.DatabaseType.ToString();
            var instance = databaseInterfaceType.Assembly.GetTypes().FirstOrDefault(x =>
             databaseInterfaceType.IsAssignableFrom(x)
             &&
             string.Equals(instanceType, x.Name, StringComparison.OrdinalIgnoreCase));
            services.AddSingleton((IDatabaseType)Activator.CreateInstance(instance));
        }

    }
}
