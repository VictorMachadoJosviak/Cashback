using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Domain.Entities
{
    public class Sale : EntityBase
    {
        public string Code { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public virtual Reseller Reseller { get; set; }
        public Guid? ResellerId { get; set; }
        public virtual StatusSale StatusSale { get; set; }
        public int StatusSaleId { get; set; }
    }
}
