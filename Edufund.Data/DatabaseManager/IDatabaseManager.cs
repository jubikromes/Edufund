using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.DatabaseManager
{
    public interface IDatabaseManager
    {
        string GetDataBaseName(string tenantId);
    }
}
