using Edufund.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Databasefactory
{
    public interface IContextFactory
    {
        IDbContext DbContext { get; }
    }
}
