using Biblioteca.ConsoleApp;

public class Leitor
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public int Idade { get; set; }
    public List<Livro> Livros { get; set; } = new List<Livro>();

    public Leitor(string nome, string cpf, int idade)
    {
        Nome = nome;
        Cpf = cpf;
        Idade = idade;
    }
}
//Iago Henrique Schlemper
//Eduardo Da Silva Ramos