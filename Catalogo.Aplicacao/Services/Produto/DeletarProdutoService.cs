using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.Interface.Produto;
using Catalogo.Domain.Exceptions;

namespace Catalogo.Aplicacao.Services.Produto
{
    public class DeletarProdutoService : IDeletarProduto
    {
        private readonly AppDBContext _dbContext;
        public DeletarProdutoService(AppDBContext dbContext) =>_dbContext = dbContext;

        public async Task Executar(int id)
        {
            var produto = _dbContext.Produtos.FirstOrDefault(produto => produto.ProdutoId == id);

            if (produto == null)
                throw new RecursoNaoEncontradoException("Produto não encontrado.");
                
           _dbContext.Remove(produto);
           await _dbContext.SaveChangesAsync();
        }
    }
}
