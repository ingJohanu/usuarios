using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usuarios.Models;

namespace Web.API.Authentication
{
    public interface ITokenProvider
    {

        /*Generar Token*/
        string CreateToken(tbl_admin admin, DateTime expiry);
        TokenValidationParameters GetValidationParameters();
    }
}
