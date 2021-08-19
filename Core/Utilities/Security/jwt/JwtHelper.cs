using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            //tokenoptions bilgierini alıp _tokenOpitons a atıyoruz
            //nesne haline getirdik.

            _tokenOptions = configuration.GetSection(key: "TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        }
        public AccessToken CreateToken(Kullanici kullanici, List<Rol> Roller)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, kullanici, signingCredentials, Roller);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration

            };
        }
        

   
    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Kullanici kullanici, SigningCredentials signingCredentials, List<Rol> Roller)
    {
        var jwt = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience: tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(kullanici, Roller),
            signingCredentials: signingCredentials
            );
        return jwt;
    }
    private IEnumerable<Claim> SetClaims(Kullanici kullanici, List<Rol> roller)
    {
        var claims = new List<Claim>();
        claims.AddNameIdentifier(kullanici.Id.ToString());
        claims.AddKullaniciAdi(kullanici.KullaniciAdi);
        claims.AddAd($"{kullanici.Ad} {kullanici.Soyad}");
        claims.AddRoller(roller.Select(c => c.RolAdi).ToArray());
        return claims;

    }

}
}
