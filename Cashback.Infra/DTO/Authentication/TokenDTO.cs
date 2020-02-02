using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Infra.DTO.Authentication
{
    public class TokenDTO
    {
        public string access_token { get; set; }
        public DateTime expires_in { get; set; }
        public string token_type { get; set; }

    }
}
