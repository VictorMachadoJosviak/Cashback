using Cashback.Domain.Entities;
using Cashback.Infra.Presistence;
using Cashback.Repository.Base;
using Cashback.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.Repository
{
    public class ResellerRepository : RepositoryBase<Reseller, Guid>, IResellerRepository
    {
        private readonly DataContext dataContext;
        public ResellerRepository(DataContext _dataContext) : base(_dataContext)
        {
            dataContext = _dataContext;
        }

        public async Task<Reseller> FindResellerByCPF(string cpf)
        {
            return FindBy(x => x.CPF == cpf);
        }
    }
}
