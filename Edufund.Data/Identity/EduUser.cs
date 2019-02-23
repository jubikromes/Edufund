using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Identity
{
    public class EduUser : IdentityUser<string>
    {
        public virtual ICollection<EduUserClaim> Claims { get; set; }
        public virtual ICollection<EduUserLogin> Logins { get; set; }
        public virtual ICollection<EduUserToken> Tokens { get; set; }
        public virtual ICollection<EduUserRole> UserRoles { get; set; }

        public int Kyc { get; set; }
        public string NextofKinName { get; set; }
        public string NextofKinNumber { get; set; }
        public string SecurityQuestion1 { get; set; }
        public string SecurityQuestion2 { get; set; }
        public string SecurityQuestion3 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string SecurityAnswer3 { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }


        public string Address1 { get; set; }
        public string Address2 { get; set; }

    }
}
