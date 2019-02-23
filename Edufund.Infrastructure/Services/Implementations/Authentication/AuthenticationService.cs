using Edufund.Data.Context;
using Edufund.Data.Identity;
using Edufund.Infrastructure.Models;
using Edufund.Infrastructure.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Services.Implementations
{
    public class AuthenticationService
    {
        private readonly UserManager<EduUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        //use repository instead
        private readonly IDbContext _context;
        public AuthenticationService(UserManager<EduUser> userManager,
                    IJwtFactory jwtFactory,
                    IOptions<JwtIssuerOptions> jwtOptions,
                    IDbContext context)
        {

        }
    }
}
