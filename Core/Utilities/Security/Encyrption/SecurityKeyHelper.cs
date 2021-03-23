using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encyrption
{
    public class SecurityKeyHelper
    {
        //elimizdeki stringleri byte array haline getiriyior
        //kısaca jwt ihtiyaç duyduğu yapı
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
