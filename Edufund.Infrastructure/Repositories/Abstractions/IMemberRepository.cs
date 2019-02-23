using Edufund.Data.Entities;
using Edufund.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Repositories.Abstractions
{
    public interface IMemberRepository : IRepository<Member, int>, IAsyncRepository<Member,int>
    {
    }
}
