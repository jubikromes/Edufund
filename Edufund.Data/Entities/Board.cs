using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Entities
{
    public class Board : BaseEntity<int>
    {
        public decimal InitialInvestedCapital { get; set; }

        public bool AutoRenew { get; set; }

        public int MemberCount { get; set; }

        public int ReferralCount { get; set; }

        public int UplineCount { get; set; }

        public int Cycles { get; set; }

        public int NoPerCycle { get; set; }

        public List<EduFundSystem> EduFundSystem { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
