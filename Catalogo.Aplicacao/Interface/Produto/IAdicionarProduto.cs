using Catalogo.Aplicacao.DTO;
using Catalogo.Aplicacao.DTO.Request;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Aplicacao.Interface.Produto
{
    public interface IAdicionarProduto
    {
        void Executar(ProdutoRequestDto produto);
    }
}
