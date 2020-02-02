using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cashback.Infra.Enums
{
    public enum SaleStatus
    {
        [Description("Em Validação")]

        InValidation = 1,

        [Description("Aprovado")]
        Approved = 2
    }
}
