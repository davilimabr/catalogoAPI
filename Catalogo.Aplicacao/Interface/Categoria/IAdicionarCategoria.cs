using Catalogo.Aplicacao.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Interface.Categoria
{
    public interface IAdicionarCategoria
    {
        Task Executar(CategoriaRequestDto categoria);
    }
}
