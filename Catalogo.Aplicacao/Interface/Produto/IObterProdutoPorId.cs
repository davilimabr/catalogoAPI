using Catalogo.Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Interface.Produto
{
    public interface IObterProdutoPorId
    {
        ProdutoDto Executar(int id);
    }
}
