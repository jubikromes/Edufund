using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Infrastructure.Config
{
    public class AutoMapperConfiguration 
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.AddProfile<GeneralMapping>();
                //cfg.AddProfile<CustomerMapping>();
            });
        }
    }
}
