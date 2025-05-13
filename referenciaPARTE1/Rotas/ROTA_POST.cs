using REFERENCIAPARTE1.Models;

public static class Rota_POST
{
    public static void MapPostRoutes(this WebApplication app)
    {
        app.MapPost("/livros", async (Livro livro, LivrosContext context) =>
        {
            context.Livros.Add(livro);
            await context.SaveChangesAsync();
            return Results.Created($"/livros/{livro.Id}", livro);
        });
    }
}
