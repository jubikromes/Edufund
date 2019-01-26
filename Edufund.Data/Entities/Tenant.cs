using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Entities
{
    public class Tenant : BaseEntity<int>
    {
        public string Title { get; set; }
    }
}
