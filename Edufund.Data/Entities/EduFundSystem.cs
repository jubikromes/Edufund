using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Entities
{
    public class EduFundSystem : BaseEntity<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal EntryFee { get; set; }

        public int BoardId { get; set; }
        public Board Board { get; set; }
    }
}
