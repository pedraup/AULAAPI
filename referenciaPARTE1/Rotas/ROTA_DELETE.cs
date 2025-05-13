using REFERENCIAPARTE1.Models;

public static class Rota_DELETE
{
    public static void MapDeleteRoutes(this WebApplication app)
    {
        app.MapDelete("/livros/{id}", async (int id, LivrosContext context) =>
        {
            var livro = await context.Livros.FindAsync(id);
            if (livro is null) return Results.NotFound();

            context.Livros.Remove(livro);
            await context.SaveChangesAsync();
            return Results.Ok();
        });
    }
}
