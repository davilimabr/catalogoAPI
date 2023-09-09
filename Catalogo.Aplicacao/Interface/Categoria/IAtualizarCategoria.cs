using Catalogo.Aplicacao.DTO.Request;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Interface.Categoria
{
    public interface IAtualizarCategoria
    {
        void Executar(CategoriaModel categoria);
    }
}
