using Catalogo.Aplicacao.Interface.Produto;
using Catalogo.Aplicacao.Services.Produto;
using Catalogo.Aplicacao.Services.Produtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Ioc.InjecaoDependencias
{
    public static class ServiceInjecaoDependencia
    {
        public static void AddServices(this IServiceCollection servicos)
        {
            servicos.AddScoped<IObterProdutos, ObterProdutosService>();
            servicos.AddScoped<IObterProdutoPorId, ObterProdutoPorIdService>();
            servicos.AddScoped<IAdicionarProduto, AdicionarProdutoService>();
            servicos.AddScoped<IAtualizarProduto, AtualizarProdutoService>();
            servicos.AddScoped<IDeletarProduto, DeletarProdutoService>();
        }
    }
}
