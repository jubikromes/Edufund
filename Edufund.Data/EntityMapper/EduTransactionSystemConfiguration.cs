using Edufund.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.EntityMapper
{
    public class EduTransactionConfiguration : IEntityTypeConfiguration<EduTransaction>
    {
        public void Configure(EntityTypeBuilder<EduTransaction> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
