using Cashback.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cashback.API.Controllers.Base
{
    public class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async Task<IActionResult> ResponseAsync(object result)
        {
            if (result != null && ModelState.IsValid)
            {
                try
                {
                    
                    _unitOfWork.Commit();

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500,"Erro interno no servidor");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        protected async Task<IActionResult> ResponseAsync()
        {
            return await ResponseAsync(new object());
        }
    }
}
