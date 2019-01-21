using Edufund.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.EntityMapper
{
    public class EduWalletConfiguration : IEntityTypeConfiguration<EduWallet>
    {
        public void Configure(EntityTypeBuilder<EduWallet> builder)
        {
            builder.HasKey(p => p.Id);

        }
    }
}
