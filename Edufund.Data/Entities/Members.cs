using Edufund.Data.Identity;
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

        public List<Referral> Referrals { get; set; }
        public List<Referral> AllReferred { get; set; }


        public MemberWallet MemberWallet { get; set; }

        public int EduUserId { get; set; }
        public EduUser EduUser { get; set; }

    }
}
