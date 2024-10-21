using Fiap.Api.Donation3.Data;
using Fiap.Api.Donation3.Models;
using Fiap.Api.Donation3.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation3.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _dataContext;
        public UsuarioRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Delete(int id)
        {
            var usuario = new UsuarioModel() { UsuarioId = id };

            _dataContext.Usuarios.Remove(usuario);
            _dataContext.SaveChanges();
        }

        public IList<UsuarioModel> FindAll()
        {
            return _dataContext.Usuarios.AsNoTracking().ToList();
        }

        public async Task<UsuarioModel> FindByEmailAndSenha(string email, string senha)
        {
           var usuario = await _dataContext.Usuarios.AsNoTracking()
                .FirstOrDefaultAsync(u => u.EmailUsuario == email && u.Senha == senha);
            return usuario;
        }

        public UsuarioModel FindById(int id)
        {
            return _dataContext.Usuarios.AsNoTracking().FirstOrDefault(c => c.UsuarioId == id);
        }

        public int Insert(UsuarioModel usuarioModel)
        {
            _dataContext.Usuarios.Add(usuarioModel);
            _dataContext.SaveChanges();

            return usuarioModel.UsuarioId;
        }

        public UsuarioModel Login(string email, string senha)
        {
            var usuario = _dataContext.Usuarios.FirstOrDefault(
               u => u.EmailUsuario == email && u.Senha == senha);
            return usuario;
        }

        public void Update(UsuarioModel usuarioModel)
        {
            _dataContext.Usuarios.Update(usuarioModel);
            _dataContext.SaveChanges();
        }
    }
}
