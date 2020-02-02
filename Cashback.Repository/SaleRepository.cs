using Cashback.Domain.Entities;
using Cashback.Infra.Enums;
using Cashback.Infra.Presistence;
using Cashback.Repository.Base;
using Cashback.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.Repository
{
    public class SaleRepository : RepositoryBase<Sale, Guid>, ISaleRepository
    {
        private readonly DataContext dataContext;
        public SaleRepository(DataContext _dataContext) : base(_dataContext)
        {
            dataContext = _dataContext;
        }

        public async Task<Sale> FindSaleByIdInValidation(Guid idSale)
        {
            return FindBy(x => x.Id == idSale && x.StatusSaleId == (int)SaleStatus.InValidation);
        }
    }
}
