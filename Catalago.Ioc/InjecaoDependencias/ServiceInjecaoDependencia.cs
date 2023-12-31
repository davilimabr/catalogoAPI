﻿using Catalogo.Aplicacao.Interface.Categoria;
using Catalogo.Aplicacao.Interface.Produto;
using Catalogo.Aplicacao.Services.Categoria;
using Catalogo.Aplicacao.Services.Produto;
using Catalogo.Aplicacao.Services.Produtos;
using Microsoft.Extensions.DependencyInjection;

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

            servicos.AddScoped<IObterCategorias, ObterCategoriasService>();
            servicos.AddScoped<IObterCategoriaPorId, ObterCategoriaPorIdService>();
            servicos.AddScoped<IAdicionarCategoria, AdicionarCategoriaService>();
            servicos.AddScoped<IAtualizarCategoria, AtualizarCategoriaService>();
            servicos.AddScoped<IDeletarCategoria, DeletarCategoriaService>();
        }
    }
}
