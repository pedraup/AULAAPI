using Microsoft.EntityFrameworkCore;

namespace REFERENCIAPARTE1.Models
{
    public class LivrosContext : DbContext
    {
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
    }
}
