using Microsoft.EntityFrameworkCore;
using REFERENCIAPARTE1.Models;

public static class Rota_PUT
{
    public static void MapPutRoutes(this WebApplication app)
    {
        app.MapPut("/livros/{id}", async (int id, Livro input, LivrosContext context) =>
        {
            var livro = await context.Livros.FindAsync(id);
            if (livro is null) return Results.NotFound();

            livro.TituloLivro = input.TituloLivro;
            livro.AutorLivro = input.AutorLivro;
            livro.Ano = input.Ano;
            livro.TipoMaterial = input.TipoMaterial;
            livro.Citacao = input.Citacao;

            await context.SaveChangesAsync();
            return Results.Ok(livro);
        });
    }
}
