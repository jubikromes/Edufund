using Edufund.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.EntityMapper
{
    public class ReferralConfiguration : IEntityTypeConfiguration<Referral>
    {
        public void Configure(EntityTypeBuilder<Referral> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Refered).WithMany(t => t.AllReferred).HasForeignKey(p => p.ReferedId);
            builder.HasOne(p => p.Referer).WithMany(t => t.Referrals).HasForeignKey(p => p.RefererId);
        }
    }
}
