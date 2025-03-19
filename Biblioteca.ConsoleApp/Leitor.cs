using System;
using System.Collections.Generic;
namespace Biblioteca.ConsoleApp;

public class Leitor
{
    public string Nome { get; }
    public string Cpf { get; }
    public int Idade { get; }
    public List<Livro> Livros = new List<Livro>(); // Lista de livros do leitor

    public Leitor(string nome, string cpf, int idade)
    {
        if (nome == "" || cpf == "" || idade < 0)
        {
            throw new ArgumentException("Valores inválidos.");
        }

        Nome = nome.Trim();
        Cpf = cpf.Trim();
        Idade = idade;
    }
}
//Iago Henrique Schlemper
//Eduardo Da Silva Ramos