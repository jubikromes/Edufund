﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Models
{
    public class RegistrationModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }
        public string UserName { get; set; }
    }
}
