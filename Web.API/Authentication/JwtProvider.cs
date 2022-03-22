using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using usuarios.Models;

namespace Web.API.Authentication
{
    public class JwtProvider:ITokenProvider
    {
        /*Contexto de la clase token*/
        private RsaSecurityKey _key;
        private string _algoritm;
        private string _issuer;
        private string _audiencie;

        /*Inicializamo alginos valores*/
        public JwtProvider(string issuer, string audience, string keyName)
        {
            var parameters = new CspParameters() { KeyContainerName = keyName };
            var provifer = new RSACryptoServiceProvider(2048, parameters);
            _key = new RsaSecurityKey(provifer);
            _algoritm = SecurityAlgorithms.RsaSha256Signature;
            _issuer = issuer;
            _audiencie = audience;
        }
        public string CreateToken(tbl_admin admin, DateTime expiry)
        {
            //Creamos el token
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new List<Claim>()
            {
                new Claim(ClaimTypes.Name,$"{admin.usuario}{admin.rol}"),
                new Claim(ClaimTypes.Role,admin.rol),
                new Claim(ClaimTypes.PrimarySid,admin.id.ToString()),

            }, "Custom");
            SecurityToken token = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Audience = _audiencie,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(_key, _algoritm),
                Expires = expiry.ToUniversalTime(),
                Subject = identity
            });

            return tokenHandler.WriteToken(token);
        }

        public TokenValidationParameters GetValidationParameters()
        {
            /*Retorno de la validacion del token*/
            return new TokenValidationParameters
            {
                IssuerSigningKey = _key,
                ValidAudience = _audiencie,
                ValidIssuer = _issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }
    }
}
