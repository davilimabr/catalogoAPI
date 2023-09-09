﻿using Catalogo.Aplicacao.Context;
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
    public class DeletarCategoriaService : IDeletarCategoria
    {
        private readonly AppDBContext _dbContext;
        public DeletarCategoriaService(AppDBContext dBcontext) => _dbContext = dBcontext;
       
        public void Executar(int id)
        {
            var categoria = _dbContext.Categorias.FirstOrDefault(c => c.CategoriaId == id);

            if (categoria != null)
            {
                _dbContext.Remove(categoria);
                _dbContext.SaveChanges();
            }
        }
    }
}
