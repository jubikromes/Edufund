using Edufund.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Services.Abstractions
{
    public interface IEduFundSystemService
    {
        EduFundSystemDto GetEduFund();
    }
}
