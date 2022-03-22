using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using usuarios.UnitOfWork;
using usuarios.Models;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitoOfWork;
        public UsuariosController(IUnitOfWork IUnitOfWork)
        {
            _IUnitoOfWork = IUnitOfWork;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_IUnitoOfWork.Users.GetById(id));
        }

        [HttpGet]
        [Route("GetPaginateUsers/{page:int}/{rows:int}")]
        public IActionResult GetPaginateUsers(int page, int rows)
        {
            /*Ejemplo de error*/
            //throw new System.Exception("Services ERROR");
            return Ok(_IUnitoOfWork.Users.UsersPagedList(page, rows));
        }

        [HttpPost]
        [Route("Add")]
        /*SE especifica en los metodos, que recuper del BY id*/
        public IActionResult Add([FromBody] tbl_users usuarios)
        {
            /*Validar el modelo que recivira el controlador*/
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_IUnitoOfWork.Users.Insert(usuarios));
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] tbl_users usuarios)
        {
            /*Validamos modelo y actualizacion en DB*/
            if (ModelState.IsValid && _IUnitoOfWork.Users.Update(usuarios))
            {
                return Ok(new { Message = "The customer Update" });
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromBody] tbl_users usuarios)
        {
            if (usuarios.id > 0)
                return Ok(_IUnitoOfWork.Users.Delete(usuarios));
            return BadRequest();
        }
    }
}
