using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cashback.API.Controllers.Base;
using Cashback.Infra.DTO.Reseller;
using Cashback.Infra.Transactions;
using Cashback.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cashback.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class ResellerController : BaseController
    {
      
        private readonly IResellerService _resellerService;

        public ResellerController(IUnitOfWork unitOfWork,IResellerService resellerService):base(unitOfWork)
        {
            _resellerService = resellerService;
        }

        /// <summary>
        /// Cadastra um revendedor
        /// </summary>
        /// <param name="reseller"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateReseller(CreateResellerDTO reseller)
        {
            var result = await _resellerService.CreateReseller(reseller);
            return await ResponseAsync(result);
        }


    }
}
