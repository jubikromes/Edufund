using Edu.WebApi.Models;
using Edufund.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Edufund.Infrastructure.Services.Abstractions
{
    public interface IAccountService
    {
        Task<BaseResponseModel> RegisterAsync(RegistrationModel model);
        Task<ResponseModel<TokenViewModel>> LoginAsync(CredentialsModel model);
    }
}
