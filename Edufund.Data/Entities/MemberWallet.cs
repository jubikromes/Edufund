using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Entities
{
    public class MemberWallet : BaseEntity<int>
    {
        public decimal Balance { get; set; }
        public string Name { get; set; }
    }
}
