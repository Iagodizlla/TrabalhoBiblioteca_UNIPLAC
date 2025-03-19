using System;
using System.Collections.Generic;
namespace Biblioteca.ConsoleApp;

public class Livro
{
    public string Titulo { get; }
    public string Autor { get; }
    public string SubTitulo { get; }
    public string Isbn { get; }
    public string Editora { get; }
    public string Genero { get; }
    public int AnoPublicacao { get; }
    public int NumeroPaginas { get; }
    public string TipoCapa { get; }

    public Livro(string titulo, string autor, string subtitulo, string isbn, string editora, string genero, int anop, int numerop, string tipocapa)
    {
        if (titulo == "" || autor == "" || subtitulo == "" || isbn == "" || editora == "" || genero == "" || anop < 0 || numerop < 0 || tipocapa == "")
        {
            throw new ArgumentException("Valores inválidos.");
        }
        Titulo = titulo.Trim();
        Autor = autor.Trim();
        SubTitulo = subtitulo.Trim();
        Isbn = isbn.Trim();
        Editora = editora.Trim();
        Genero = genero.Trim();
        TipoCapa = tipocapa.Trim();
        AnoPublicacao = anop;
        NumeroPaginas = numerop;
    }
}
//Iago Henrique Schlemper
//Eduardo Da Silva Ramos