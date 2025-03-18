using System;
using System.Collections.Generic;
namespace Biblioteca.ConsoleApp;

public class Program
{
    static List<Leitor> leitores = new List<Leitor>(){
        new Leitor("João Silva", "123.456.789.00", 23)
        { Livros = new List<Livro> {
        new Livro("Dom Casmurro", "Machado de Assis")}},

        new Leitor("Maria Souza", "987.654.321.00", 18)
        { Livros = new List<Livro> {
        new Livro("1984", "George Orwell"),
        new Livro("O Senhor dos Aneis", "J.R.R. Tolkien"),
        new Livro("O cu do Mundo", "Josue Pereira"),
        new Livro("O grito", "Arthur Machado")}},

        new Leitor("Iago Henrique Schlemper", "123.456.789.99", 19)
        { Livros = new List<Livro> { 
        new Livro("Amanda do Ceu", "Amanda Pereira")}},

        new Leitor("Eduardo da Silva Ramos", "012.983.133.22", 19){}
    }; // Lista para armazenar todos os leitores cadastrados

    static void Main()
    {
        while (true)
        {
            ExibirMenu(); // Exibe o menu de opções

            string opcao = Console.ReadLine()!;
            Console.WriteLine();

            SelecionarOpcao(opcao);
            if(opcao == "0")
                return;

            Console.ReadLine();
        }
    }
    public static void ExibirMenu()
    {
        Console.Clear();
        // Exibe o menu de opções
        Console.WriteLine("=== Biblioteca ===");
        Console.WriteLine("1. Cadastrar Leitor");
        Console.WriteLine("2. Listar Leitores");
        Console.WriteLine("3. Cadastrar Livro");
        Console.WriteLine("4. Listar Livros de um Leitor");
        Console.WriteLine("5. Excluir Leitor");
        Console.WriteLine("6. Editar Leitor");
        Console.WriteLine("7. Transferir Livro");
        Console.WriteLine("0. Sair");
        Console.Write("Escolha uma opção: ");
    }
    public static void SelecionarOpcao(string opcao)
    {
        // Executa a ação correspondente à opção escolhida
        switch (opcao)
        {
            case "1": CadastrarLeitor(); break;
            case "2": ListarLeitores(); break;
            case "3": CadastrarLivro(); break;
            case "4": ListarLivrosDoLeitor(); break;
            case "5": ExcluirLeitor(leitores); break;
            case "6": EditarLeitor(); break;
            case "7": TranferirLivro(); break;
            case "0": return;
            default: Console.WriteLine("Opção inválida!\n"); break;
        }
    }
    public static void TranferirLivro()
    {
        Console.Write("Digite o CPF do Leitor que irá transferir o livro: ");
        string cpf = Console.ReadLine()!;

        Leitor leitor = BuscarLeitor(cpf);

        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!\n");
            return;
        }

        Console.Write("Digite o CPF do Leitor que irá receber o livro: ");
        string cpfReceber = Console.ReadLine()!;

        Leitor leitorReceber = BuscarLeitor(cpfReceber);

        if (leitorReceber == null)
        {
            Console.WriteLine("Leitor não encontrado!\n");
            return;
        }

        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine()!;

        Livro livro = leitor.Livros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))!;

        if (livro == null)
        {
            Console.WriteLine("Livro não encontrado!\n");
            return;
        }

        leitorReceber.Livros.Add(livro);
        leitor.Livros.Remove(livro);

        Console.WriteLine("Livro transferido com sucesso!\n");
    }
    public static void EditarLeitor()
    {
        Console.Write("Digite o CPF do Leitor: ");
        string cpf = Console.ReadLine()!;

        Leitor leitor = BuscarLeitor(cpf);

        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!\n");
            return;
        }

        Console.Write("Digite o novo nome do Leitor: ");
        string nome = Console.ReadLine()!;
        Console.Write("Digite a nova idade do Leitor: ");
        int idade = int.Parse(Console.ReadLine()!);

        leitor.Nome = nome;
        leitor.Idade = idade;

        Console.WriteLine("Leitor editado com sucesso!\n");
    }
    static void ExcluirLeitor(List<Leitor> leitores)
    {
        Console.Write("Digite o CPF do Leitor: ");
        string cpf = Console.ReadLine()!;

        Leitor leitor = BuscarLeitor(cpf);

        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!\n");
            return;
        }

        leitores.Remove(leitor);
        Console.WriteLine("Leitor excluído!\n");
    }

    static void CadastrarLeitor()
    {
        Console.Write("Digite o CPF do Leitor: ");
        string cpf = Console.ReadLine()!;

        // Verifica se o CPF já está cadastrado
        if (leitores.Exists(l => l.Cpf == cpf))
        {
            Console.WriteLine("Erro: CPF já cadastrado!\n");
            return;
        }
        Console.Write("Digite o nome do Leitor: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite a idade do Leitor: ");
        int idade = int.Parse(Console.ReadLine()!);

        leitores.Add(new Leitor(nome, cpf, idade)); // Adiciona um novo Leitor à lista
        Console.WriteLine("Leitor cadastrado com sucesso!\n");
    }

    static void ListarLeitores()
    {
        if (leitores.Count == 0)
        {
            Console.WriteLine("Nenhum Leitor cadastrado.\n");
            return;
        }

        // Percorre a lista de leitores e exibe seus nomes, CPFs e a quantidade de livros que possuem
        for (int i = 0; i < leitores.Count; i++)
        {
            Console.WriteLine($"Leitor: {leitores[i].Nome} | CPF: {leitores[i].Cpf} | Idade: {leitores[i].Idade} ({leitores[i].Livros.Count} livros)");
        }
        Console.WriteLine();
    }

    static Leitor BuscarLeitor(string cpf)
    {
        // Busca um Leitor pelo CPF
        return leitores.Find(l => l.Cpf.Equals(cpf, StringComparison.OrdinalIgnoreCase))!;
    }

    static void CadastrarLivro()
    {
        Console.Write("Digite o CPF do Leitor: ");
        string cpf = Console.ReadLine()!;
        Leitor leitor = BuscarLeitor(cpf);

        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!\n");
            return;
        }

        // Solicita as informações do livro e adiciona à lista de livros do Leitor
        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine()!;
        Console.Write("Digite o autor do livro: ");
        string autor = Console.ReadLine()!;
        leitor.Livros.Add(new Livro(titulo, autor));

        Console.WriteLine("Livro cadastrado com sucesso!\n");
    }

    static void ListarLivrosDoLeitor()
    {
        Console.Write("Digite o CPF do Leitor: ");
        string cpf = Console.ReadLine()!;
        Leitor leitor = BuscarLeitor(cpf);

        if (leitor == null)
        {
            Console.WriteLine("Leitor não encontrado!\n");
            return;
        }

        // Exibe a lista de livros do Leitor
        Console.WriteLine($"Livros de {leitor.Nome} (CPF: {leitor.Cpf}):");
        for (int i = 0; i < leitor.Livros.Count; i++)
        {
            Console.WriteLine($"- {leitor.Livros[i].Titulo} ({leitor.Livros[i].Autor})");
        }
        Console.WriteLine();
    }
}
//Iago Henrique Schlemper
//Eduardo Da Silva Ramos