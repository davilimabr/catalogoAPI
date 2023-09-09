using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.Interface.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Services.Produto
{
    public class DeletarProdutoService : IDeletarProduto
    {
        private readonly AppDBContext _dbContext;
        public DeletarProdutoService(AppDBContext dbContext) =>_dbContext = dbContext;

        public void Executar(int id)
        {
            var produto = _dbContext.Produtos.FirstOrDefault(produto => produto.ProdutoId == id);

            if (!(produto is null))
            {
                _dbContext.Remove(produto);
                _dbContext.SaveChanges();
            }
        }
    }
}
