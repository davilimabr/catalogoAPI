using AutoMapper;
using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.DTO;
using Catalogo.Aplicacao.Interface.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Services.Produtos
{
    public class ObterProdutosService : IObterProdutos
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        public ObterProdutosService(AppDBContext dBcontext, IMapper mapper)
        {
            _dbContext = dBcontext;
            _mapper = mapper;
        } 

        public IEnumerable<ProdutoDto> Executar()
        {
            var produtos = _dbContext.Produtos.ToList();
            return _mapper.Map<IEnumerable<ProdutoDto>>(produtos); 
        }
    }
}
