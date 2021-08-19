using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddKullaniciAdi(this ICollection<Claim> claims,string kullaniciAdi)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, value: kullaniciAdi));
        }
        public static void AddAd(this ICollection<Claim> claims, string ad)
        {
            claims.Add(new Claim(ClaimTypes.Name, value: ad));
        }
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, value: nameIdentifier));
        }
        public static void AddRoller(this ICollection<Claim> claims, string[] roller)
        {
            roller.ToList().ForEach(rol => claims.Add((new Claim (ClaimTypes.Role, value: rol))));
      
        }
    }
}
