using AutoMapper;
using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.DTO.Response;
using Catalogo.Aplicacao.Interface.Categoria;
using Catalogo.Aplicacao.Interface.Produto;
using Catalogo.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Services.Categoria
{
    public class ObterCategoriaPorIdService : IObterCategoriaPorId
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public ObterCategoriaPorIdService(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoriaResponseDto> Executar(int id)
        {
            var categoria = await _dbContext.Categorias.Include(p => p.Produtos).FirstOrDefaultAsync(c => c.CategoriaId == id);

            if (categoria == null)
                throw new RecursoNaoEncontradoException("Categoria não encontrada.");

            return _mapper.Map<CategoriaResponseDto>(categoria); 
        }
    }
}
