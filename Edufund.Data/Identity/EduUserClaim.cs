using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Identity
{
    public class EduUserClaim : IdentityUserClaim<string>
    {
        public virtual EduUser User { get; set; }
    }
}
