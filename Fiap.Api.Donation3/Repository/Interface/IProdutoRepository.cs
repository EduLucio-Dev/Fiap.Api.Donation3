using Fiap.Api.Donation3.Models;

namespace Fiap.Api.Donation3.Repository.Interface
{
    public interface IProdutoRepository
    {
        public IList<ProdutoModel> FindAll();
        public IList<ProdutoModel> FindAll(int pagina, int tamanho);
        public IList<ProdutoModel> FindAll(DateTime? dataRef, int tamanho);
        public int Count();

        public ProdutoModel FindById(int id);
        public int Insert(ProdutoModel produtoModel);
        public void Delete(int id);
        public void Update(ProdutoModel produtoModel);
    }
}