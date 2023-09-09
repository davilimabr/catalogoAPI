using AutoMapper;
using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.DTO.Response;
using Catalogo.Aplicacao.Interface.Categoria;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Services.Categoria
{
    public class ObterCategoriasService : IObterCategorias
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public ObterCategoriasService(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaResponseDto>> Executar()
        {
            var categorias = await _dbContext.Categorias.Include(p => p.Produtos).ToListAsync();
            return _mapper.Map<IEnumerable<CategoriaResponseDto>>(categorias);
        }
    }
}
