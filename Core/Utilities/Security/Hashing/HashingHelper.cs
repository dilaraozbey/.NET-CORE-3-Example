using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   public class HashingHelper
    {
        //out: her yerde değişikliği göster demek
        public static void CreatePasswordHash(string sifre,out byte[]passwordHash,out byte[]passwordSalt)
        {
            
            using(var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(buffer: Encoding.UTF8.GetBytes(sifre)); 
            }
        }
        public static bool VerifyPasswordHash(string sifre, byte[] passwordHash, byte[] passwordSalt)
            //passwordHash veritabanından gelen
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                var computedHash = hmac.ComputeHash(buffer: Encoding.UTF8.GetBytes(sifre));
                for(int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return true;
                    }
                   
                }
            }
            return false;
        }

        
    }
}
