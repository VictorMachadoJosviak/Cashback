using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Infra.DTO.Sale
{
    public class CreateSaleDTO
    {
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string CPF { get; set; }
    }
}
