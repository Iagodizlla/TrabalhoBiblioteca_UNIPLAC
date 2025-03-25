public class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Editora { get; set; }
    public string ISBN { get; set; }
    public string Resumo { get; set; }
    public string Genero { get; set; }
    public int AnoPublicacao { get; set; }
    public int NumeroPaginas { get; set; }
    public string TipoCapa { get; set; }

    public Livro(string titulo, string autor, string resumo, string isbn, string editora, string genero, int anoPublicacao, int numeroPaginas, string tipoCapa)
    {
        Titulo = titulo;
        Autor = autor;
        Resumo = resumo;
        ISBN = isbn;
        Editora = editora;
        Genero = genero;
        AnoPublicacao = anoPublicacao;
        NumeroPaginas = numeroPaginas;
        TipoCapa = tipoCapa;
    }
}

//Iago Henrique Schlemper
//Eduardo Da Silva Ramos