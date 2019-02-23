using Edu.WebApi.Models;
using Edufund.Data.Context;
using Edufund.Data.Entities;
using Edufund.Data.Identity;
using Edufund.Infrastructure.Models;
using Edufund.Infrastructure.Repositories.Abstractions;
using Edufund.Infrastructure.Services.Abstractions;
using Edufund.Infrastructure.UnitofWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using Edufund.Infrastructure.Utilities.Helpers;
using Edufund.Data.Configuration.Helpers;

namespace Edufund.Infrastructure.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<EduUser> _userManager;
        private readonly UserManager<EduRole> _roleManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        //use repository instead
        private readonly IUnitofWork _unitofWork;
        public AccountService(UserManager<EduUser> userManager,
                    IJwtFactory jwtFactory,
                    IOptions<JwtIssuerOptions> jwtOptions,
                    IUnitofWork unitofWork, UserManager<EduRole> roleManager)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _unitofWork = unitofWork;
            _roleManager = roleManager;
        }
        public async Task<BaseResponseModel> RegisterAsync(RegistrationModel model)
        {
            var response = new BaseResponseModel {
                Message = "User could not be created.",
                HasError = true
            };
            var user = new EduUser
            {
                LastName = model.LastName,
                Email = model.Email,
                FirstName = model.FirstName,
                UserName = model.UserName,
            };
            var identityUserResult = await _userManager.CreateAsync(user,  model.Password);
            if (!identityUserResult.Succeeded)
            {
                response.Message = identityUserResult.Errors.ToList().FirstOrDefault()?.Description;
                return response;
            }
            var identityRoleResult = await _userManager.AddToRoleAsync(user, Settings.MemberRole);
            response.Message = "User created successfully.";
            response.HasError = false;
            var memberToAdd = new Member
            {
                EduUserId = user.Id,
                Cycle = 0,
                OrderBy = 2,
            };

            var addedMember = await _unitofWork.MemberRepository.AddAsync(memberToAdd);
            await _unitofWork.SaveChanges();
            return response;
        }
        public async Task<ResponseModel<TokenViewModel>> LoginAsync(CredentialsModel model)
        {
            var response = new ResponseModel<TokenViewModel> {
                Message = "User not logged in.",
                HasError = true
            };
            var identity = await GetClaims(model.UserName, model.Password);
            if (identity == null)
            {
                response.Message = "Could not generate token";
                response.HasError = true;
                return response;
            }
            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, model.UserName, _jwtOptions, new JsonSerializerSettings { Formatting = Formatting.Indented });
            response.Result = jwt;
            response.HasError = false;
            response.Message = "User logged in.";
            return response;
        }
        private async Task<ClaimsIdentity> GetClaims(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);
            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(username);
            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(username, userToVerify.Id));
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
