using Microsoft.EntityFrameworkCore;
using Catalogo.Domain.Models;

namespace Catalogo.Aplicacao.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
