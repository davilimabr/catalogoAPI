using Catalogo.Ioc.InjecaoDependencias;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogo.Ioc
{
    public static class InjecaoDependencia
    {
        public static void AddDependencias(this IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AddMapper();
            servicos.AddDbContext(configuracao);
            servicos.AddServices();
            servicos.AddApplicationInsightsTelemetry();
        }
    }
}
