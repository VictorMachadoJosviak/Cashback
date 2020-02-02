using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Infra.DTO.Reseller
{
    public class CreateResellerDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Password { get; set; }
    }

}
