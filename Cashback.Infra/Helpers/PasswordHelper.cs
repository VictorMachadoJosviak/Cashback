using BCrypt.Net;
using Cashback.Infra.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cashback.Infra.Helpers
{
    public static class PasswordHelper
    {
        public static string ToHash(this string input)
        {
            var hashed = BCrypt.Net.BCrypt.EnhancedHashPassword(input, HashType.SHA512);
            return hashed;
        }
        public static bool VerifyHash(this string input, string hashed)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(input, hashed, HashType.SHA512);
        }
    }
}
