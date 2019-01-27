using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Databasefactory
{
    public interface IContextFactory
    {
        DbContext DbContext { get; set; }
    }
}
