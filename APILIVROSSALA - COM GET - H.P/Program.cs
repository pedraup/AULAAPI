using ApiLivros.Routes;  // Importa as rotas definidas em ROTA_GET.cs

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Chamando as rotas GET definidas no arquivo separado
app.MapGetRoutes();

app.Run();
