using Fiap.Api.Donation3.Models;

namespace Fiap.Api.Donation3.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public void Delete(int id);

        public IList<UsuarioModel> FindAll();

        public UsuarioModel FindById(int id);

        public int Insert(UsuarioModel usuarioModel);

        public void Update(UsuarioModel usuarioModel);
    }
}
