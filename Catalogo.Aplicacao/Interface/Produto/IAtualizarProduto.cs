using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Interface.Produto
{
    public interface IAtualizarProduto
    {
        void Executar(ProdutoModel produto);
    }
}
