﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Utilities.Helpers
{
    public static class Constants
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";

                //policy

                public const string Pol_ApiAccess_Key = "ApiUser";
                public const string Pol_ApproveVehicle_Key = "ApproveVehicle";
            }

            public static class JwtClaims
            {

                //roles 
                public const string Role_Administrator = "admin";
                public const string Role_Support = "support";
                public const string Role_Member = "member";

                //reference for permission access
                //https://docs.microsoft.com/en-us/aspnet/core/security/authorization/secure-data?view=aspnetcore-2.1


                public const string Pol_ApiAccess = "api_access";
                public const string Pol_ApproveVehicle = "approve_vehicle";

            }
        }
    }
}
