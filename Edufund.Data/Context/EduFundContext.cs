using Edufund.Data.EntityMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Context
{
    public class EduFundContext : DbContext
    {
        public EduFundContext(DbContextOptions<EduFundContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberWalletConfiguration());
        }
    }
}
