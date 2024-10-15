using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository;
using Fiap.Api.Donation3.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Api.Donation3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public ActionResult<IList<UsuarioModel>> Get()
        {
            var listaUsuarios = _usuarioRepository.FindAll();
            if (listaUsuarios != null && listaUsuarios.Count > 0)
            {
                return Ok(listaUsuarios);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("{id:int}")]
        public ActionResult<UsuarioModel> Get([FromRoute] int id)
        {
            var usuarioModel = _usuarioRepository.FindById(id);

            if (usuarioModel != null)
            {
                return Ok(usuarioModel);
            }
            else
            {
                return NotFound(usuarioModel);
            }
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete([FromRoute] int id)
        {

            if (id == 0)
            {
                return BadRequest();
            }

            var categoria = _usuarioRepository.FindById(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _usuarioRepository.Delete(id);
            return NoContent();
        }


        [HttpPost]
        public ActionResult<UsuarioModel> Post([FromBody] UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                var usuarioId = _usuarioRepository.Insert(usuarioModel);
                usuarioModel.UsuarioId = usuarioId;
                return CreatedAtAction(nameof(Get), new { id = usuarioId }, usuarioModel);

            }
            else
            {
                return BadRequest();
            }
        }



        [HttpPut("{id:int}")]
        public ActionResult Put([FromRoute] int id, [FromBody] UsuarioModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(m => m.ErrorMessage);
                return BadRequest(errors);
            }

            if (id != usuarioModel.UsuarioId)
            {
                return BadRequest(new { erro = "Ids divergentes, operação não efetuada" });
            }

            var categoria = _usuarioRepository.FindById(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _usuarioRepository.Update(usuarioModel);
            return NoContent();
        }
    }
}
