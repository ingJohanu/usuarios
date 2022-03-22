using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usuarios.Models;
using usuarios.UnitOfWork;
using Web.API.Authentication;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenProvider _ItokenProvider;
        private IUnitOfWork _IUnitOfWork;
        /*Constructor*/
        public TokenController(ITokenProvider tokenProvider, IUnitOfWork iunitOfWork)
        {
            _ItokenProvider = tokenProvider;
            _IUnitOfWork = iunitOfWork;
        }
        /*Creamos metodos de autentificación*/
        [HttpPost]
        public JsonWebToken PostToken([FromBody] tbl_admin userlogin)
        {
            var user = _IUnitOfWork.Admin.ValidateAdmin(userlogin.usuario, userlogin.contraseña);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            var token = new JsonWebToken
            {
                Access_Token = _ItokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_In = 480//minutes
            };
            return token;
        }
    }
}
