using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Infra.DTO.Sale
{
    public class UpdateSaleDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }    
        public Guid? ResellerId { get; set; }
        public int StatusSaleId { get; set; }
    }
}
