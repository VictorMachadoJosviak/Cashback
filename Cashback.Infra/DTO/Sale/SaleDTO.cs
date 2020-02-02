using Cashback.Infra.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Infra.DTO.Sale
{
    public class SaleDTO
    {
        public Guid Id { get; set; }
        public SaleStatus SaleStatus { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public Guid? ResellerId { get; set; }
    }
}
