﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Identity
{
    public class EduUserToken : IdentityUserToken<string>
    {
        public virtual EduUser User { get; set; }
    }
}
