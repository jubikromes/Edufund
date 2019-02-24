using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Identity
{
    public class EduUser : IdentityUser<int>
    {
        public virtual ICollection<EduUserClaim> Claims { get; set; }
        public virtual ICollection<EduUserLogin> Logins { get; set; }
        public virtual ICollection<EduUserToken> Tokens { get; set; }
        public virtual ICollection<EduUserRole> UserRoles { get; set; }


        public string LastName { get; set; }
        public string FirstName { get; set; }


        public string Address1 { get; set; }
        public string Address2 { get; set; }

    }
}
