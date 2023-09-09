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

namespace Catalogo.Aplicacao.Services.Produto
{
    public class ObterProdutoPorIdService : IObterProdutoPorId
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;
        public ObterProdutoPorIdService(AppDBContext dBcontext, IMapper mapper)
        {
            _dbContext = dBcontext;
            _mapper = mapper;
        }

        public ProdutoResponseDto Executar(int id)
        {
            var produto = _dbContext.Produtos.Include(c => c.Categoria).FirstOrDefault(produto => produto.ProdutoId == id);
            return _mapper.Map<ProdutoResponseDto>(produto);
        }
    }
}
