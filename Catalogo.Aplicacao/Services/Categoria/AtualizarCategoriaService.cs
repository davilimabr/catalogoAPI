using Catalogo.Aplicacao.Context;
using Catalogo.Aplicacao.Interface.Categoria;
using Catalogo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Services.Categoria
{
    public class AtualizarCategoriaService : IAtualizarCategoria
    {
        private readonly AppDBContext _dbContext;
        public AtualizarCategoriaService(AppDBContext dBcontext) => _dbContext = dBcontext;
        public async Task Executar(CategoriaModel categoria)
        {
            _dbContext.Entry(categoria).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
