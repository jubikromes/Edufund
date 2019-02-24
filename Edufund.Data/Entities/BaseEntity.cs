using Edufund.Data.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Entities
{
    // This can easily be modified to be BaseEntity<T> and public T Id to support different key types.
    // Using non-generic integer types for simplicity and to ease caching logic
    public class BaseEntity<T>
    {
        public T Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public Guid? CreatedById { get; set; }
        public EduUser CreatedBy { get; set; }
        public Guid? ModifiedById { get; set; }
        public EduUser ModifiedBy { get; set; }

    }
}
