﻿using Edu.WebApi.Models;
using Edufund.Data.Entities;
using Edufund.Infrastructure.DTO;
using Edufund.Infrastructure.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Services.Implementations
{
    public class EduFundSystemService
    {
        private readonly EfRepository<EduFundSystem, int> _eduFundRepository;
        public EduFundSystemService(EfRepository<EduFundSystem, int> eduFundRepository)
        {
            _eduFundRepository = eduFundRepository;
        }
        public ResponseModel<EduFundSystemDto> GetEduFund(int id)
        {
            var eduFund = _eduFundRepository.GetById(id);
            return new ResponseModel<EduFundSystemDto> {
                Message = "",
                HasError = false,
                Result =
                {
                    CreatedDate = eduFund.CreatedDate,
                    ModifiedDate = eduFund.ModifiedDate,
                    Boards = eduFund.Boards,
                    Description = eduFund.Description,
                    EntryFee = eduFund.EntryFee,
                    Title = eduFund.Title
                }
            };
        }
    }
}
