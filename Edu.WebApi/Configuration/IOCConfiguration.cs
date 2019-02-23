using Edufund.Data;
using Edufund.Data.Databasefactory;
using Edufund.Data.DatabaseManager;
using Edufund.Infrastructure.Repositories.Abstractions;
using Edufund.Infrastructure.Repositories.Implementations;
using Edufund.Infrastructure.Services.Abstractions;
using Edufund.Infrastructure.Services.Implementations;
using Edufund.Infrastructure.UnitofWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edu.WebApi.Configuration
{
    public static class IOCConfiguration
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
            services.AddScoped(typeof(IAsyncRepository<,>), typeof(EfRepository<,>));
            services.AddScoped<IEduFundSystemService, EduFundSystemService>();
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddTransient<IDatabaseManager, EduContextDatabaseManager>();
            services.AddTransient<IContextFactory, EdufundContextFactory>();
        }
    }
}
