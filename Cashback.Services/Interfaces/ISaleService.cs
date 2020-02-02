using Cashback.Infra.DTO.Accumulate;
using Cashback.Infra.DTO.Authentication;
using Cashback.Infra.DTO.Cashback;
using Cashback.Infra.DTO.Sale;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.Services.Interfaces
{
    public interface ISaleService
    {
        Task<SaleDTO> CreateSale(CreateSaleDTO Sale);
        Task<SaleDTO> UpdateSale(UpdateSaleDTO Sale);
        Task<List<CashbackDTO>> ListCashbacks();
        Task<bool> CodeNotExists(string code);
        Task DeleteSale(Guid idSale);
        Task<CashbackDTO> FindAccumulatedCashbackByCpf(string cpf);
    }
}
