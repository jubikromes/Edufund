using Edufund.Data.Configuration;
using Edufund.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Data.Common;
using System.Data.SqlClient;


namespace Edufund.Data.Configuration
{
    public class MsSql : IDatabaseType
    {
        /// <inherit/>
        public IServiceCollection EnableDatabase(IServiceCollection services, IOptions<ConnectionSettings> connectionOptions)
        {
            return services;
        }

        /// <inherit/>
        public DbConnectionStringBuilder GetConnectionBuilder(string connectionString)
        {
            return new SqlConnectionStringBuilder(connectionString);
        }

        /// <inherit/>
        public DbContextOptionsBuilder GetContextBuilder(DbContextOptionsBuilder optionsBuilder, IOptions<ConnectionSettings> connectionOptions, string connectionString)
        {
            return optionsBuilder.UseSqlServer(connectionString, b => EntityFrameworkConfiguration.GetMigrationInformation(b));
        }

        /// <inherit/>
        public DbContextOptionsBuilder<TContext> SetConnectionString<TContext>(DbContextOptionsBuilder<TContext> contextOptionsBuilder, string connectionString) where TContext : DbContext
        {
            return contextOptionsBuilder.UseSqlServer(connectionString);
        }
    }
}
