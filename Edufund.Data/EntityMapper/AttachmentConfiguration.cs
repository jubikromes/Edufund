using System;
using System.Collections.Generic;
using System.Text;
using Edufund.Data.Entities;

namespace Edufund.Data.EntityMapper
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
        }
    }
}
