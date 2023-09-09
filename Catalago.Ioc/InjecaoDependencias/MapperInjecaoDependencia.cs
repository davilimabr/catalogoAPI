using AutoMapper;
using Catalogo.Aplicacao.Mappings;
using Catalogo.Aplicacao.Mappings.Categoria;
using Catalogo.Aplicacao.Mappings.Produto;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Ioc.InjecaoDependencias
{
    public static class MapperInjecaoDependencia
    {
        public static void AddMapper(this IServiceCollection servicos)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProdutoMappings());
                mc.AddProfile(new CategoriaMappings());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            servicos.AddSingleton(mapper);
        }
    }
}
