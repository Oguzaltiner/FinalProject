using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        internal static string ProductsListed = "ürünler listelendi";
        internal static string MaintenanceTime = "sistem bakımda";

        public static string AuthorizationDenied = "Yetkin yok";
        public static string UserNotFound = "Kullanıcı yok";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated ="Token oluşturuldu";
        public static string UserRegistered ="Kullanıcı kayıtlı";
    }
}
