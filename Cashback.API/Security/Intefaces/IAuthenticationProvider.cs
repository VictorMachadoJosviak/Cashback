using Cashback.Infra.DTO.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback.API.Security.Intefaces
{
    public interface IAuthenticationProvider
    {
        Task<TokenDTO> GenerateToken(Guid userId);
    }
}
