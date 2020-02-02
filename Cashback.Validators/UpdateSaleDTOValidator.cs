using Cashback.Infra.DTO.Sale;
using Cashback.Infra.Extensions;
using Cashback.Services.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Validators
{
    public class UpdateSaleDTOValidator : AbstractValidator<UpdateSaleDTO>
    {
        private readonly ISaleService _saleService;
        public UpdateSaleDTOValidator(ISaleService saleService)
        {
            _saleService = saleService;

            RuleFor(x => x.Code).NotNull().MaximumLength(20)
                .Must(ValidateCode).WithMessage("Código já cadastrado");

            RuleFor(x => x.Value).GreaterThan(0);

            RuleFor(x => x.StatusSaleId).GreaterThan(0);
        }

        private bool ValidateCode(string code)
        {
            return _saleService.CodeNotExists(code).Result;
        }

    }
}
