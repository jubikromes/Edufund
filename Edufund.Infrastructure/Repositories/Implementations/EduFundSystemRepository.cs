﻿using Edufund.Data.Context;
using Edufund.Data.Databasefactory;
using Edufund.Data.Entities;
using Edufund.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Repositories.Implementations
{
    public class EduFundSystemRepository : EfRepository<EduFundSystem, int>, IEduFundSystemRepository
    {
        public EduFundSystemRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
