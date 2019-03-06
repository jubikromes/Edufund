using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Entities
{
    public class Staff : BaseEntity<int>
    {
        public int? PassportId { get; set; }
        public Attachment Passport { get; set; }
    }
}
