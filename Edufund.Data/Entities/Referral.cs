using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Entities
{
    public class Referral : BaseEntity<int>
    {

        public int? ReferedId { get; set; }
        public Member Refered { get; set; }

        public int? RefererId { get; set; }
        public Member Referer { get; set; }


    }
}
