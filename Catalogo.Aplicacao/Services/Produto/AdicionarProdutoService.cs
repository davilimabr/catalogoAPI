using AutoMapper;
using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.DTO;
using Catalogo.Aplicacao.Interface.Produto;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Services.Produto
{
    public class AdicionarProdutoService : IAdicionarProduto
    {
        private readonly AppDBContext _dbContext;
        public AdicionarProdutoService(AppDBContext dBcontext) => _dbContext = dBcontext;   
        
        public void Executar(ProdutoModel produto)
        {
            _dbContext.Produtos.Add(produto);
            _dbContext.SaveChanges();   
        }
    }
}
