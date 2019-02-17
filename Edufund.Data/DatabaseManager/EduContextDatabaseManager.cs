﻿using Edufund.Data.DatabaseManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data
{
    public class EduContextDatabaseManager : IDatabaseManager
    {
        /// <summary>
        /// IMPORTANT NOTICE: The solution uses simple dictionary for demo purposes.
        /// The Best "Real-life" solutions would be creating 'RootDataBase' with 
        /// all Tenants Parameters/Options like: TenantName, DatabaseName, other configuration.
        /// </summary>
        private readonly Dictionary<Guid, string> tenantConfigurationDictionary = new Dictionary<Guid, string>
        {
            {
                Guid.Parse("b0ed668d-7ef2-4a23-a333-94ad278f45d7"), "EduDb"
            },
            {
                Guid.Parse("e7e73238-662f-4da2-b3a5-89f4abb87969"), "EduDb-Ghana"
            }
        };
        /// <summary>
        /// Gets the name of the data base.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns>db name</returns>
        public string GetDataBaseName(string tenantId)
        {
            var dataBaseName = this.tenantConfigurationDictionary[Guid.Parse(tenantId)];
            if (dataBaseName == null)
            {
                throw new ArgumentNullException(nameof(dataBaseName));
            }
            return dataBaseName;
        }
    }
}
