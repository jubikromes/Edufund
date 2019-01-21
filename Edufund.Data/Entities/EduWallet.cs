using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Entities
{
    public class EduWallet : BaseEntity<Guid>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Balance { get; set; }
    }
}
