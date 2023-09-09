using Catalogo.Aplicacao.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Ioc.InjecaoDependencias
{
    public static class DbContextInjecaoDependencia
    {
        public static void AddDbContext(this IServiceCollection servicos, IConfiguration configuracao)
        {
            var mySqlConnection = configuracao.GetConnectionString("DefaultConnetion");
            servicos.AddDbContext<AppDBContext>(
                options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
        }
    }
}
