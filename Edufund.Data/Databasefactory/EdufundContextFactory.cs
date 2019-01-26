using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data
{
    public class EdufundContextFactory
    {
        private const string TenantIdFieldName = "tenantid";
        private const string DatabaseFieldKeyword = "Database";

        private readonly HttpContext httpContext;

        private readonly IOptions<ConnectionSettings> settings;
        private readonly IDataBaseManager dataBaseManager;
    }
}
