using Microsoft.EntityFrameworkCore;
using REFERENCIAPARTE1.Models;
using REFERENCIAPARTE1.Rotas;

var builder = WebApplication.CreateBuilder(args);

// Configura o banco SQLite
builder.Services.AddDbContext<LivrosContext>(options =>
    options.UseSqlite("Data Source=livros.db"));

// Configura o CORS para permitir qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");

// Mapeia as rotas REST
app.MapGetRoutes();
app.MapPostRoutes();
app.MapPutRoutes();
app.MapDeleteRoutes();

// Popular o banco com dados iniciais, se estiver vazio
PopularBancoDeDados(app);

// Inicia a aplicação
app.Run();

void PopularBancoDeDados(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<LivrosContext>();

    context.Database.Migrate();

    if (!context.Livros.Any())
    {
        var livrosIniciais = new List<Livro>
        {
            new() { Id = 1, TituloLivro = "Referência 1", AutorLivro = "Autor 1", Ano = 2020, TipoMaterial = "Livro", Citacao = "Autor 1 (2020)" },
            new() { Id = 2, TituloLivro = "Referência 2", AutorLivro = "Autor 2", Ano = 2021, TipoMaterial = "Artigo", Citacao = "Autor 2 (2021)" }
            // Continue com até 20 referências reais se desejar
        };

        context.Livros.AddRange(livrosIniciais);
        context.SaveChanges();
    }
}
