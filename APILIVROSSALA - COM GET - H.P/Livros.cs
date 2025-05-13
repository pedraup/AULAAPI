namespace ApiLivros.Models;

public class Livro
{
    public int Id { get; set; }        // Identificador único
    public string Titulo { get; set; } // Nome do livro
    public string Autor { get; set; }  // Nome do autor
    public int AnoPublicacao { get; set; } // Ano de publicação
}