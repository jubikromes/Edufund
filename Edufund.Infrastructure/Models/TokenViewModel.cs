using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Models
{
    public class TokenViewModel
    {
        public string id { get; set; }
        public string auth_token { get; set; }
        public double expires_in { get; set; }
    }
}
