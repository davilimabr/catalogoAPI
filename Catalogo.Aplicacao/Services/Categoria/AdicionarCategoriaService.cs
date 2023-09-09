using AutoMapper;
using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.DTO.Request;
using Catalogo.Aplicacao.Interface.Categoria;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Services.Categoria
{
    public class AdicionarCategoriaService : IAdicionarCategoria
    {
        private readonly AppDBContext _dbContext;
        private readonly IMapper _mapper;

        public AdicionarCategoriaService(AppDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Executar(CategoriaRequestDto categoria)
        {
            var categoriaModel = _mapper.Map<CategoriaModel>(categoria);
            
            _dbContext.Categorias.Add(categoriaModel);
            _dbContext.SaveChanges();
        }
    }
}
