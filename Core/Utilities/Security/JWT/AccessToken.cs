using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //erişim anahtarı
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime  Expiration { get; set; }

    }
}
