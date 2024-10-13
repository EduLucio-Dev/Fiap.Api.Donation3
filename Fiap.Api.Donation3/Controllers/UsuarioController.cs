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
        public IList<UsuarioModel> Get()
        {
            var listaUsuarios = _usuarioRepository.FindAll();
            return listaUsuarios;
        }
        [HttpGet("{id:int}")]
        public UsuarioModel Get([FromRoute] int id)
        {
            return _usuarioRepository.FindById(id);
        }


        [HttpDelete("{id:int}")]
        public bool Delete([FromRoute] int id)
        {
            _usuarioRepository.Delete(id);
            return true;
        }


        [HttpPost]
        public UsuarioModel Post([FromBody] UsuarioModel usuarioModel)
        {
            var id = _usuarioRepository.Insert(usuarioModel);
            usuarioModel.UsuarioId = id;
            return usuarioModel;
        }



        [HttpPut("{id:int}")]
        public bool Put([FromRoute] int id, [FromBody] UsuarioModel usuarioModel)
        {
            if (id == usuarioModel.UsuarioId)
            {
                _usuarioRepository.Update(usuarioModel);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
