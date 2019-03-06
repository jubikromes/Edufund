using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Entities
{
    public class Attachment : BaseEntity<int>
    {
        public string AttachmentUrl { get; set; }
        public string FileName { get; set; }
    }
}
