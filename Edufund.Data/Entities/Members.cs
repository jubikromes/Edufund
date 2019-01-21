using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Entities
{
    public class Member : BaseEntity<int>
    {
        public int Cycle { get; set; }

        public int? ParentMemberId { get; set; }

        public int? OrderBy { get; set; }

        public int? WalletId { get; set; }

        public MemberWallet MemberWallet { get; set; }
    }
}
