using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Identity
{
    public class EduRoleClaim : IdentityRoleClaim<string>
    {
        public virtual EduRole Role { get; set; }
    }
}
