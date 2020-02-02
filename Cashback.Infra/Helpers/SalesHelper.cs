using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Infra.Helpers
{
    public static class SalesHelper
    {
        public const string SALES_CPF_APPROVED = "15350946056";

        public static decimal GetPercentageCashback(this decimal @value)
        {
            return value > 0M    && value <= 1000M ? 10M : 
                   value > 1000M && value <=1500M  ? 15M : 
                   value > 1500M ? 20M : 0M;
        }

        public static decimal CalculatePercentageCashback(this decimal @value)
        {
            var percent = GetPercentageCashback(value);
            return percent > 0 ? value * percent / 100M : 0M;
        }
    }
}
