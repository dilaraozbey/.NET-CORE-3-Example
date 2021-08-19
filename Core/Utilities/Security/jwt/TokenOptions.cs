using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.jwt
{
    public class TokenOptions
    {
        //kullanici kitlesi
        public string Audience { get; set; }
        //imzalayan
        public string Issuer { get; set; }
        //dakika cinsindem
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
