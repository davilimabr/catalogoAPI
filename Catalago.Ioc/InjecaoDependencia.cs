using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalogo.Ioc.InjecaoDependencias;

namespace Catalogo.Ioc
{
    public static class InjecaoDependencia
    {
        public static void AddDependencias(this IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AddMapper();
            servicos.AddDbContext(configuracao);
            servicos.AddServices();
        }        
    }
}
