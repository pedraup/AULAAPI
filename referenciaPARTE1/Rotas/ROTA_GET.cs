using Microsoft.EntityFrameworkCore;
using REFERENCIAPARTE1.Models;

namespace REFERENCIAPARTE1.Rotas
{
    public static class Rota_GET
    {
        public static void MapGetRoutes(this WebApplication app)
        {
            app.MapGet("/livros", async (LivrosContext context) =>
            {
                var livros = await context.Livros.ToListAsync();
                return Results.Ok(livros);
            });

            app.MapGet("/livros/{id}", async (int id, LivrosContext context) =>
            {
                var livro = await context.Livros.FindAsync(id);
                return livro is not null ? Results.Ok(livro) : Results.NotFound();
            });
        }
    }
}
