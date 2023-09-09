using AutoMapper;
using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.DTO;
using Catalogo.Aplicacao.DTO.Request;
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
        private readonly IMapper _mapper;
        public AdicionarProdutoService(AppDBContext dBcontext, IMapper mapper)
        {
            _dbContext = dBcontext;
            _mapper = mapper;
        } 
        
        public async Task Executar(ProdutoRequestDto produto)
        {
            var produtoModel = _mapper.Map<ProdutoModel>(produto);

            _dbContext.Produtos.Add(produtoModel);
            await _dbContext.SaveChangesAsync();   
        }
    }
}
