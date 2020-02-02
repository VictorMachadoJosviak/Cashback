using Cashback.Infra.DTO.Authentication;
using Cashback.Infra.DTO.Reseller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.Services.Interfaces
{
    public interface IResellerService
    {
        Task<ResellerDTO> Authenticate(CredentialsDTO credentials);
        Task<ResellerDTO> CreateReseller(CreateResellerDTO reseller);
        Task<bool> CPFNotExists(string cpf);
        Task<bool> EmailNotExists(string email);
    }
}
