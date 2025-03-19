using System;
using System.Collections.Generic;
namespace Biblioteca.ConsoleApp;
public class Leitor
{
    public string Nome { get; set; }
    public string Cpf { get; }
    public int Idade { get; set; }
    public List<Livro> Livros = new List<Livro>();

    public Leitor(string nome, string cpf, int idade)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio.");

        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("CPF não pode ser vazio.");

        if (idade <= 0)
            throw new ArgumentException("Idade deve ser maior que zero.");

        Nome = nome.Trim();
        Cpf = cpf.Trim();
        Idade = idade;
    }
}
//Iago Henrique Schlemper
//Eduardo Da Silva Ramos