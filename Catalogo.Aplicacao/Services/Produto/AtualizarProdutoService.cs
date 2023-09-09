using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.Interface.Produto;
using Catalogo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Services.Produto
{
    public class AtualizarProdutoService : IAtualizarProduto
    {
        private readonly AppDBContext _dbContext;
        public AtualizarProdutoService(AppDBContext dBcontext) => _dbContext = dBcontext;
        public void Executar(ProdutoModel produto)
        {
            _dbContext.Entry(produto).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
