using Catalogo.Aplicacao.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Interface.Produto
{
    public interface IObterProdutos
    {
        IEnumerable<ProdutoResponseDto> Executar();
    }
}
