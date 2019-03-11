using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptSharp;
namespace MyLoyalty.Models
{
    public static class EncryptHash
    {
        public static string Encript(string pass)
        {
            return Crypter.MD5.Crypt(pass);
        }

        public static bool CheckPass(string pass, string hash)
        {
            return Crypter.CheckPassword(pass, hash);
        }
    }
}
