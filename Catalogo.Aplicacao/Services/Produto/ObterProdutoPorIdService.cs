using AutoMapper;
using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.DTO.Response;
using Catalogo.Aplicacao.Interface.Produto;
using Catalogo.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ProdutoResponseDto> Executar(int id)
        {
            var produto = await _dbContext.Produtos.Include(c => c.Categoria).FirstOrDefaultAsync(produto => produto.ProdutoId == id);

            if (produto == null)
                throw new RecursoNaoEncontradoException("Produto não encontrado.");

            return _mapper.Map<ProdutoResponseDto>(produto);
        }
    }
}
