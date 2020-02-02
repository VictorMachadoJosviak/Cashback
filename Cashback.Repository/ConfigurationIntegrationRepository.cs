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
    public class ConfigurationIntegrationRepository : RepositoryBase<ConfigurationIntegration, Guid>, IConfigurationIntegrationRepository
    {
        public ConfigurationIntegrationRepository(DataContext _context) : base(_context)
        {
        }

        public async Task<ConfigurationIntegration> FindByName(string name)
        {
            return FindBy(x => x.Name == name);
        }
    }
}
