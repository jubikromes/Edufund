using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Identity
{
    public class EduRole : IdentityRole<int>
    {
        public virtual ICollection<EduUserRole> UserRoles { get; set; }
        public virtual ICollection<EduRoleClaim> RoleClaims { get; set; }
    }
}
