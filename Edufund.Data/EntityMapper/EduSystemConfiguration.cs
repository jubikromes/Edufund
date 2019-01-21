using Edufund.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.EntityMapper
{
    public class EduSystemConfiguration : IEntityTypeConfiguration<EduFundSystem>
    {
        public void Configure(EntityTypeBuilder<EduFundSystem> builder)
        {
            builder.HasKey(p => p.Id);

        }
    }
}
