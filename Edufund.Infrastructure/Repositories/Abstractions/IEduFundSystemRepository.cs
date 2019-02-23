using Edufund.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Repositories.Abstractions
{
    public interface IEduFundSystemRepository : IRepository<EduFundSystem, int>, IAsyncRepository<EduFundSystem, int>
    {
    }
}
