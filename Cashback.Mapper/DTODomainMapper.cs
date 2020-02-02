using AutoMapper;
using Cashback.Domain.Entities;
using Cashback.Infra.DTO.Reseller;
using Cashback.Infra.DTO.Sale;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Mapper
{
    public class DTODomainMapper : Profile
    {
        public DTODomainMapper()
        {
            CreateMap<ResellerDTO, Reseller>();

            CreateMap<CreateSaleDTO, Sale>()
                .ForPath(x => x.Reseller.CPF, opt => opt.MapFrom(x => x.CPF));

            CreateMap<UpdateSaleDTO, Sale>();
        }
    }
}
