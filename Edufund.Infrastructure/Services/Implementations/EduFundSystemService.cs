using Edu.WebApi.Models;
using Edufund.Data.Entities;
using Edufund.Infrastructure.DTO;
using Edufund.Infrastructure.Repositories.Implementations;
using Edufund.Infrastructure.Services.Abstractions;
using Edufund.Infrastructure.UnitofWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Edufund.Infrastructure.Services.Implementations
{
    public class EduFundSystemService : IEduFundSystemService
    {
        private readonly IUnitofWork _unitofWork;
        public EduFundSystemService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public async Task<BaseResponseModel> CreateEduFundSystem(EduFundSystemDto systemDto)
        {
            var response = new BaseResponseModel { };

            var eduFundRepo = _unitofWork.GetRepository<EduFundSystem, int>();
            var createdEntity = eduFundRepo.Add(new EduFundSystem
            {
                Description = systemDto.Description,
                EntryFee = systemDto.EntryFee,
                Title = systemDto.Title,
            });
            await _unitofWork.SaveChanges();
            response.Message = "Entity Created";
            return response;
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
