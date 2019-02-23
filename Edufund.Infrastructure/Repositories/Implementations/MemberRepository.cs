using Edufund.Data.Context;
using Edufund.Data.Entities;
using Edufund.Infrastructure.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Repositories.Implementations
{
    public class MemberRepository : EfRepository<Member, int>, IMemberRepository
    {
        public MemberRepository(IDbContext eduFundContext): base(eduFundContext)
        {

        }
    }
}
