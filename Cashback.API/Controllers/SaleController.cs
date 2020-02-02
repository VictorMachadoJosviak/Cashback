using Cashback.API.Controllers.Base;
using Cashback.Infra.DTO.Sale;
using Cashback.Infra.Transactions;
using Cashback.Services.Interfaces;
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
    public class SaleController : BaseController
    {
        private readonly ISaleService _saleService;
        public SaleController(IUnitOfWork unitOfWork, ISaleService saleService) : base(unitOfWork)
        {
            _saleService = saleService;
        }

        /// <summary>
        /// Lista todas as vendas
        /// </summary>
        /// <returns></returns>
        /// <response code="401">Token inválido</response>
        /// <response code="400">Requisição inválida</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> List()
        {
            var list = await _saleService.ListCashbacks();
            return await ResponseAsync(list);
        }


        /// <summary>
        /// Efetua uma busca na api externa pelo cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        /// <response code="401">Token inválido</response>
        /// <response code="400">Requisição inválida</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("cashback/{cpf}")]
        public async Task<IActionResult> GetCashback(string cpf)
        {
            var credit = await _saleService.FindAccumulatedCashbackByCpf(cpf);
            return await ResponseAsync(credit);
        }

        /// <summary>
        /// Cadastra uma venda
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        /// <response code="401">Token inválido</response>
        /// <response code="400">Requisição inválida</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Create(CreateSaleDTO sale)
        {
            var createSale = await _saleService.CreateSale(sale);
            return await ResponseAsync(createSale);
        }

        /// <summary>
        /// Atualiza as vendas (apenas em validação)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <response code="401">Token inválido</response>
        /// <response code="400">Requisição inválida</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(UpdateSaleDTO dto)
        {
            var update = _saleService.UpdateSale(dto);
            return await ResponseAsync(dto);
        }


        /// <summary>
        /// Excuir vendas (apenas em validação)
        /// </summary>
        /// <param name="idSale"></param>
        /// <returns></returns>
        /// <response code="401">Token inválido</response>
        /// <response code="400">Requisição inválida</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Route("{idSale}")]
        public async Task<IActionResult> DeleteSale(Guid idSale)
        {
            await _saleService.DeleteSale(idSale);
            return await ResponseAsync();
        }

    }
}
