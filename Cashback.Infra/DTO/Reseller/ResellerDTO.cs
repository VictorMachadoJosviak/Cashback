using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Infra.DTO.Reseller
{
    public class ResellerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
    }
}
