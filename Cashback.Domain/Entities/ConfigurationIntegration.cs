using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cashback.Domain.Entities
{
    public class ConfigurationIntegration : EntityBase
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public string Url { get; set; }
        public string TokenType { get; set; }
    }
}
