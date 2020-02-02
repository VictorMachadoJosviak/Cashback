using Cashback.Infra.DTO.Reseller;
using Cashback.Infra.Extensions;
using Cashback.Services.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cashback.Validators
{
    public class CreateResellerDTOValidator : AbstractValidator<CreateResellerDTO>
    {
        private readonly IResellerService _resellerService;
        public CreateResellerDTOValidator(IResellerService resellerService)
        {
            _resellerService = resellerService;

            RuleFor(x => x.Name).NotNull().WithMessage("Nome é obrigratório").MaximumLength(500);

            RuleFor(x => x.Email).NotNull().WithMessage("Email é obrigratório")
                                 .Must(ValidateEmail).WithMessage("Digite um email válido")
                                 .Must(EmailExists).WithMessage("Email já cadastrado")
                                 .MaximumLength(500);

            RuleFor(x => x.CPF).NotNull().WithMessage("CPF é obrigratório")
                               .Must(VerifyExistsCPF).WithMessage("Já existe um cpf cadastrado")
                               .Must(ValidateCPF).WithMessage("Cpf inválido")                               
                               .MaximumLength(11);

            RuleFor(x => x.Password).NotNull().WithMessage("Senha é obrigratório");
            RuleFor(x => x.LastName).MaximumLength(500);
        }

        private bool EmailExists(string email)
        {
            return _resellerService.EmailNotExists(email).Result;
        }

        private bool ValidateEmail(string email)
        {
            return email.IsValidEmailAddress();
        }

        private bool ValidateCPF(string cpf)
        {
            return cpf.IsValidCpf();
        }
        private  bool VerifyExistsCPF(string cpf)
        {
            return _resellerService.CPFNotExists(cpf.RemoveCpfMask()).Result;            
        }
    }
}
