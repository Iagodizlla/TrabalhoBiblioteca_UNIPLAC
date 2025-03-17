using System;
using System.Collections.Generic;
namespace Biblioteca.ConsoleApp;

public class Leitor
{
    public string Nome = "";
    public string Cpf = "";
    public int Idade = 0;
    public List<Livro> Livros = new List<Livro>(); // Lista de livros do leitor

    public Leitor(string nome, string cpf, int idade)
    {
        Nome = nome;
        Cpf = cpf;
        Idade = idade;
    }

    internal static void Excluir(Leitor leitor)
    {
        throw new NotImplementedException();
    }
}
//Iago Henrique Schlemper
//Eduardo Da Silva Ramos