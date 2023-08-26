using APICatalago.Domain;
using Microsoft.EntityFrameworkCore;

namespace APICatalago.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> produtos { get; set; }
    }
}
