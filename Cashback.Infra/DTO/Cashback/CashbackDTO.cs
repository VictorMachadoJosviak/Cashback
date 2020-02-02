using Cashback.Infra.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Infra.DTO.Cashback
{
    public class CashbackDTO
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string Percentage { get; set; }
        public string Value { get; set; } 
        public string DiscountedValue { get; set; }
        public string ValueWithDiscount { get; set; }
        public string Status { get; set; }
    }
}
