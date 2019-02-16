using Edu.WebApi.Models;
using Edufund.Data.Entities;
using Edufund.Infrastructure.DTO;
using Edufund.Infrastructure.Repositories.Implementations;
using Edufund.Infrastructure.Services.Abstractions;
using Edufund.Infrastructure.UnitofWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Services.Implementations
{
    public class EduFundSystemService : IEduFundSystemService
    {
        private readonly IUnitofWork _unitofWork;
        public EduFundSystemService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public BaseResponseModel CreateEduFundSystem(EduFundSystemDto systemDto)
        {
            throw new NotImplementedException();
        }

        public ResponseModel<EduFundSystemDto> GetEduFund(int id)
        {
            var response = new ResponseModel<EduFundSystemDto> { };
            var eduFundRepo = _unitofWork.GetRepository<EduFundSystem, int>();
            var edufund = eduFundRepo.GetById(id);
            if (edufund == null)
            {
                response.HasError = false;
                response.Message = "Edu Fund does not exist";
            }
            return response;
        }

    }
}
