using Edu.WebApi.Models;
using Edufund.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Services.Abstractions
{
    public interface IEduFundSystemService
    {
        ResponseModel<EduFundSystemDto> GetEduFund(int id);

        BaseResponseModel CreateEduFundSystem(EduFundSystemDto systemDto);
    }
}
