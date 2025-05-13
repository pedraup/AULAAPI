using ApiLivros.Models;

namespace ApiLivros.Routes;

public static class ROTA_GET
{
    public static void MapGetRoutes(this WebApplication app)
    {
        // Lista de livros simulando um banco de dados
        List<Livro> livros = new List<Livro>
        {
            new Livro { Id = 1, Titulo = "Dom Casmurro", Autor = "Machado de Assis", AnoPublicacao = 1899 },
            new Livro { Id = 2, Titulo = "1984", Autor = "George Orwell", AnoPublicacao = 1949 },
            new Livro { Id = 3, Titulo = "O Hobbit", Autor = "J.R.R. Tolkien", AnoPublicacao = 1937 }
        };

        // ROTA GET raiz
        app.MapGet("/", () => "API de Livros em funcionamento!");

        // ROTA GET — Listar todos os livros
        app.MapGet("/api/livros", () => livros);

        // ROTA GET — Buscar livro por ID
        app.MapGet("/api/livros/{id}", (int id) =>
        {
            var livro = livros.FirstOrDefault(l => l.Id == id);
            return livro != null ? Results.Ok(livro) : Results.NotFound("Livro não encontrado.");
        });
    }
}


