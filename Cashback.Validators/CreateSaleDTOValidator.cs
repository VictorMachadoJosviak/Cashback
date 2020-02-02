using Cashback.Infra.DTO.Sale;
using Cashback.Infra.Extensions;
using Cashback.Services.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Validators
{
    public class CreateSaleDTOValidator : AbstractValidator<CreateSaleDTO>
    {
        private readonly ISaleService _saleService;
        public CreateSaleDTOValidator(ISaleService saleService)
        {
            _saleService = saleService;

            RuleFor(x => x.CPF).NotNull().WithMessage("CPF é obrigratório")
                          .Must(ValidateCPF).WithMessage("Cpf inválido")
                          .MaximumLength(11);

            RuleFor(x => x.Code).NotNull().MaximumLength(20)
                .Must(ValidateCode).WithMessage("Código já cadastrado");

            RuleFor(x => x.Value).GreaterThan(0);
        }

        private bool ValidateCode(string code)
        {
            return _saleService.CodeNotExists(code).Result;
        }

        private bool ValidateCPF(string cpf)
        {
            return cpf.IsValidCpf();
        }
    }
}
