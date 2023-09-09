using AutoMapper;
using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.DTO.Response;
using Catalogo.Aplicacao.Interface.Produto;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<ProdutoResponseDto> Executar()
        {
            var produtos = _dbContext.Produtos.Include(c => c.Categoria).ToList();
            return _mapper.Map<IEnumerable<ProdutoResponseDto>>(produtos); 
        }
    }
}
