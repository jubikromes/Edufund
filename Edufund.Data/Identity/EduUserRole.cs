using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Identity
{
    public class EduUserRole : IdentityUserRole<int>
    {
        public virtual EduUser User { get; set; }
        public virtual EduRole Role { get; set; }
    }
}
