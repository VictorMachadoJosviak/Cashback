using Cashback.Domain.Entities;
using Cashback.Repository.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.Repository.Interfaces
{
    public interface IResellerRepository : IRepositoryBase<Reseller, Guid>
    {
        Task<Reseller> FindResellerByCPF(string cpf);

    }
}
