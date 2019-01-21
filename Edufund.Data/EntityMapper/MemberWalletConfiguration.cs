using Edufund.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.EntityMapper
{
    public class MemberWalletConfiguration : IEntityTypeConfiguration<MemberWallet>
    {
        public void Configure(EntityTypeBuilder<MemberWallet> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
