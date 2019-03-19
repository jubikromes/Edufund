using Edufund.Data.Configuration;
using Edufund.Data.Context;
using Edufund.Data.Databasefactory;
using Edufund.Data.DatabaseManager;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace Edufund.Data
{

    /// <summary>
    /// Entity Framework context service
    /// (Switches the db context according to tenant id field)
    /// </summary>
    /// https://dzone.com/articles/multi-tenant-api-based-on-swagger-entity-framework-1
    /// <seealso cref="IContextFactory" />
    public class EdufundContextFactory : IContextFactory
    {
        private const string TenantIdFieldName = "tenantid";
        private const string DatabaseFieldKeyword = "Database";

        private readonly HttpContext httpContext;

        private readonly IOptions<ConnectionSettings> connectionOptions;
        private readonly IDatabaseManager dataBaseManager;
        private readonly IDatabaseType databaseType;

        public EdufundContextFactory(
            IHttpContextAccessor httpContentAccessor,
            IOptions<ConnectionSettings> connectionSetting,
            IDatabaseManager dataBaseManager, IDatabaseType databaseType)
        {
            this.httpContext = httpContentAccessor.HttpContext;
            this.connectionOptions = connectionSetting;
            this.dataBaseManager = dataBaseManager;
            this.databaseType = databaseType;
        }


        private string TenantId
        {
            get
            {
                if (this.httpContext == null)
                {
                    throw new ArgumentNullException(nameof(this.httpContext));
                }
                string tenantId = this.httpContext.Request.Headers[TenantIdFieldName].ToString();
                if (tenantId == null)
                {
                    throw new ArgumentNullException(nameof(tenantId));
                }
                return tenantId;
            }
        }

        public IDbContext DbContext => new EduFundContext(ChangeDatabaseNameInConnectionString(this.TenantId).Options);

        private void ValidateHttpContext()
        {
            if (this.httpContext == null)
            {
                throw new ArgumentNullException(nameof(this.httpContext));
            }
        }

        private void ValidateDefaultConnection()
        {
            if (string.IsNullOrEmpty(this.connectionOptions.Value.DefaultConnection))
            {
                throw new ArgumentNullException(nameof(this.connectionOptions.Value.DefaultConnection));
            }
        }

        private DbContextOptionsBuilder<EduFundContext> ChangeDatabaseNameInConnectionString(string tenantId)
        {
            ValidateDefaultConnection();

            // 1. Create Connection String Builder using Default connection string
            var connectionBuilder = databaseType.GetConnectionBuilder(connectionOptions.Value.DefaultConnection);

            // 2. Remove old Database Name from connection string
            connectionBuilder.Remove(DatabaseFieldKeyword);

            // 3. Obtain Database name from DataBaseManager and Add new DB name to 
            connectionBuilder.Add(DatabaseFieldKeyword, this.dataBaseManager.GetDataBaseName(tenantId));

            // 4. Create DbContextOptionsBuilder with new Database name
            var contextOptionsBuilder = new DbContextOptionsBuilder<EduFundContext>();
            
            databaseType.SetConnectionString(contextOptionsBuilder, connectionBuilder.ConnectionString);

            return contextOptionsBuilder;
        }
    }

}
