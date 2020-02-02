using AutoMapper;
using Cashback.Domain.Entities;
using Cashback.Infra.DTO.Cashback;
using Cashback.Infra.DTO.Reseller;
using Cashback.Infra.DTO.Sale;
using Cashback.Infra.Enums;
using Cashback.Infra.Extensions;
using Cashback.Infra.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Mapper
{
    public class DomainDTOMapper : Profile
    {
        public DomainDTOMapper()
        {
            CreateMap<Reseller, ResellerDTO>()
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.CPF, opt => opt.MapFrom(x => x.CPF));

            CreateMap<Sale, SaleDTO>()
                .ForMember(x => x.SaleStatus, opt => opt.MapFrom(x => x.StatusSaleId))
                .AfterMap((s, d) =>
                {
                    d.Status = d.SaleStatus.GetDescription();
                });

            CreateMap<Sale, CashbackDTO>()
                .AfterMap((s, d) =>
                {
                    var percentage = s.Value.GetPercentageCashback();
                    var discountedValue = s.Value.CalculatePercentageCashback();
                    var status = (SaleStatus)s.StatusSaleId;
                    d.Percentage = $"{ percentage }%";                    
                    d.DiscountedValue = discountedValue.ToString("C2");                
                    d.ValueWithDiscount = (s.Value - discountedValue).ToString("C2");
                    d.Status = status.GetDescription();
                    d.Value = s.Value.ToString("C2");
                });
            ;
        }
    }
}
