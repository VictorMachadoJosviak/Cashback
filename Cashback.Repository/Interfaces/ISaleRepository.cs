using Cashback.Domain.Entities;
using Cashback.Repository.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.Repository.Interfaces
{
    public interface ISaleRepository : IRepositoryBase<Sale, Guid>
    {
        Task<Sale> FindSaleByIdInValidation(Guid idSale);
    }
}
