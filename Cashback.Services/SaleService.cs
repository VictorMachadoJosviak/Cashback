using AutoMapper;
using Cashback.Domain.Entities;
using Cashback.Infra.DTO.Accumulate;
using Cashback.Infra.DTO.Authentication;
using Cashback.Infra.DTO.Cashback;
using Cashback.Infra.DTO.Sale;
using Cashback.Infra.Enums;
using Cashback.Infra.Extensions;
using Cashback.Infra.Helpers;
using Cashback.Repository.Interfaces;
using Cashback.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IResellerRepository _resellerRepository;
        private readonly IConfigurationIntegrationRepository _configurationIntegrationRepository;
        private readonly IMapper _mapper;
        public SaleService(ISaleRepository saleRepository, IMapper mapper, IResellerRepository resellerRepository,
            IConfigurationIntegrationRepository configurationIntegrationRepository)
        {
            _saleRepository = saleRepository;
            _configurationIntegrationRepository = configurationIntegrationRepository;
            _resellerRepository = resellerRepository;
            _mapper = mapper;
        }

        public async Task<bool> CodeNotExists(string code)
        {
            return !_saleRepository.Exists(x => x.Code == code);
        }

        public async Task<SaleDTO> CreateSale(CreateSaleDTO dto)
        {
            var reseller = await _resellerRepository.FindResellerByCPF(dto.CPF);
            if (reseller != null)
            {
                var sale = _mapper.Map<Sale>(dto);
                sale.StatusSaleId = SalesHelper.SALES_CPF_APPROVED == reseller.CPF ? (int)SaleStatus.Approved : (int)SaleStatus.InValidation;
                sale.ResellerId = reseller.Id;
                sale.Reseller = reseller;
                var insert = _saleRepository.Add(sale);
                return _mapper.Map<SaleDTO>(insert);
            }
            return null;
        }

        public async Task DeleteSale(Guid idSale)
        {
            var sale = await _saleRepository.FindSaleByIdInValidation(idSale);
            if (sale != null)
            {
                _saleRepository.Remove(sale);
            }
        }

        public async Task<CashbackDTO> FindAccumulatedCashbackByCpf(string cpf)
        {
            var integration = await _configurationIntegrationRepository.FindByName("BOTICARIO_CASHBACK");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(integration.TokenType, integration.Token);
                var url = $"{integration.Url}/v1/cashback?cpf={cpf}";
                var response = await client.GetAsync(url);

                var json = await response.Content.ReadAsStringAsync();
                var obj = JsonConvert.DeserializeObject<JObject>(json);
                var credit = Convert.ToDecimal(obj["body"]["credit"]);

                var percentage = credit.GetPercentageCashback();
                var discountedValue = credit.CalculatePercentageCashback();
                var status = new Random().Next(0, 2);

                return new CashbackDTO
                {
                    Code = new Random().Next(0, 50000).ToString(),
                    Date = DateTime.Now,
                    Status = status == 1 ? SaleStatus.InValidation.GetDescription() : SaleStatus.Approved.GetDescription(),
                    Percentage = $"{percentage}%",
                    Value = credit.ToString("C2"),
                    DiscountedValue = discountedValue.ToString("C2"),
                    ValueWithDiscount = (credit - discountedValue).ToString("C2")
                };
            }
        }

        public async Task<List<CashbackDTO>> ListCashbacks()
        {
            var list = await _saleRepository.List(x => x.StatusSale).AsNoTracking().ToListAsync();
            return _mapper.Map<List<CashbackDTO>>(list);
        }

        public async Task<SaleDTO> UpdateSale(UpdateSaleDTO dto)
        {
            var sale = await _saleRepository.FindSaleByIdInValidation(dto.Id);
            if (sale != null)
            {
                sale.Code = dto.Code;
                sale.Date = dto.Date;
                sale.ResellerId = dto.ResellerId;
                sale.StatusSaleId = dto.StatusSaleId;
                sale.Value = dto.Value;
                sale.UpdatedAt = DateTime.Now;
                var update = _saleRepository.Edit(sale);
                return _mapper.Map<SaleDTO>(update);
            }
            return null;
        }
    }
}
