using Edufund.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.DTO
{
    public class EduFundSystemDto : BaseEntity<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal EntryFee { get; set; }

        //public int BoardId { get; set; }
        //public Board Board { get; set; }

        public List<Board> Boards { get; set; } = new List<Board> { };

    }
}
