using Cashback.API.Controllers.Base;
using Cashback.API.Security.Intefaces;
using Cashback.Infra.DTO.Authentication;
using Cashback.Infra.Transactions;
using Cashback.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IResellerService _resellerService;
        public LoginController(IUnitOfWork unitOfWork,
            IAuthenticationProvider authenticationProvider,
            IResellerService resellerService) : base(unitOfWork)
        {
            _authenticationProvider = authenticationProvider;
            _resellerService = resellerService;
        }


        /// <summary>
        /// Efetua o login na aplicação gerando um Token
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        /// <response code="401">Credenciais inválidas</response>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(CredentialsDTO credentials)
        {
            var reseller = await _resellerService.Authenticate(credentials);
            if (reseller != null)
            {
                var token = await _authenticationProvider.GenerateToken(Guid.NewGuid());
                return await ResponseAsync(token);
            }
            return Unauthorized();
        }
    }
}
