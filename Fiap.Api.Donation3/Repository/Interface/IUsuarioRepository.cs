using Fiap.Api.Donation3.Models;

namespace Fiap.Api.Donation3.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public void Delete(int id);

        public IList<UsuarioModel> FindAll();

        public UsuarioModel FindById(int id);
        public Task<UsuarioModel> FindByEmailAndSenha(string email, string senha);
        public UsuarioModel Login(string email, string senha);

        public int Insert(UsuarioModel usuarioModel);

        public void Update(UsuarioModel usuarioModel);
    }
}
