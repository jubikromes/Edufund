using Edufund.Data.Configuration.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Context
{
    public class ConnectionSettings
    {
        /// <summary>
        /// Gets or sets the database type (No sql or MsSql)
        /// </summary>
        public DatabaseType DatabaseType { get; set; }

        /// <summary>
        /// Gets or sets the default connection.
        /// </summary>
        /// <value>
        /// The default connection.
        /// </value>
        public string DefaultConnection { get; set; }
    }
    }
