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
    public class PublicacionController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitoOfWork;
        public PublicacionController(IUnitOfWork IUnitOfWork)
        {
            _IUnitoOfWork = IUnitOfWork;
        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_IUnitoOfWork.Publicacion.GetById(id));
        }

        [HttpGet]
        [Route("GetPaginateCustomer/{page:int}/{rows:int}")]
        public IActionResult GetPaginatePublicacion(int page, int rows)
        {
            /*Ejemplo de error*/
            //throw new System.Exception("Services ERROR");
            return Ok(_IUnitoOfWork.Publicacion.PublicacionPagedList(page, rows));
        }

        [HttpPost]
        [Route("Add")]
        /*SE especifica en los metodos, que recuper del BY id*/
        public IActionResult Add([FromBody] tbl_publicacion publicacion)
        {
            /*Validar el modelo que recivira el controlador*/
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_IUnitoOfWork.Publicacion.Insert(publicacion));
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] tbl_publicacion publicacion)
        {
            /*Validamos modelo y actualizacion en DB*/
            if (ModelState.IsValid && _IUnitoOfWork.Publicacion.Update(publicacion))
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
        public IActionResult Delete([FromBody] tbl_publicacion publicacion)
        {
            if (publicacion.id > 0)
                return Ok(_IUnitoOfWork.Publicacion.Delete(publicacion));
            return BadRequest();
        }
    }
}
