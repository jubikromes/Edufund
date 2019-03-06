using Edufund.Data.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int? PassportId { get; set; }
        public Attachment Passport { get; set; }

        public MemberWallet MemberWallet { get; set; }
        [ForeignKey("EduUser")]
        public int? EduUserId { get; set; }
        public EduUser EduUser { get; set; }

        public int? Kyc { get; set; }
        public string NextofKinName { get; set; }
        public string NextofKinNumber { get; set; }
        public string SecurityQuestion1 { get; set; }
        public string SecurityQuestion2 { get; set; }
        public string SecurityQuestion3 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string SecurityAnswer3 { get; set; }
    }
}
