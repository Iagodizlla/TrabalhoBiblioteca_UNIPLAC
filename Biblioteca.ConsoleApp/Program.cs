using Biblioteca.ConsoleApp;
using System;
using System.Collections.Generic;

namespace Biblioteca.ConsoleApp
{

    public class Program
    {
        public static List<Leitor> leitores = new List<Leitor>()
    {
        new Leitor("João Silva", "123.456.789.00", 23)
        {
            Livros = new List<Livro> {
                new Livro("Dom Casmurro", "Machado de Assis", "Soco Ingles", "123456789", "Machado de Assis", "Filosofia", 1999, 566, "Dura")
            }
        },

        new Leitor("Maria Souza", "987.654.321.00", 18)
        {
            Livros = new List<Livro> {
                new Livro("1984", "George Orwell", "A guerra", "121212121", "S.S.D Over", "Guerra", 1985, 300, "Dura"),
                new Livro("O Senhor dos Aneis", "J.R.R. Tolkien", "O caminho", "212121212", "D&D", "Fantasia", 1990, 990, "Dura"),
                new Livro("O cu do Mundo", "Josue Pereira", "A volta", "111111111", "Zlla", "+18", 2020, 30, "Mole"),
                new Livro("O grito", "Arthur Machado", "A revolta", "222222222", "ZONA &&&", "Terror", 2017, 289, "Mole")
            }
        },

        new Leitor("Iago Henrique Schlemper", "123.456.789.99", 19)
        {
            Livros = new List<Livro> {
                new Livro("Amanda do Ceu", "Amanda Pereira", "2", "999999999", "BR Conpani", "Comedia", 2014, 180, "Mole")
            }
        },

        new Leitor("Eduardo da Silva Ramos", "012.983.133.22", 19)
        {
        }
    }; // Lista para armazenar todos os leitores cadastrados

        public static List<Leitor> Leitores { get => leitores; set => leitores = value; }

        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sistema de Biblioteca ===");
                Console.WriteLine("1. Cadastrar Leitor");
                Console.WriteLine("2. Listar Todos os Leitores");
                Console.WriteLine("3. Adicionar Livro a um Leitor");
                Console.WriteLine("4. Listar Livros de um Leitor");
                Console.WriteLine("5. Editar Livro de um Leitor");
                Console.WriteLine("6. Remover Livro de um Leitor");
                Console.WriteLine("7. Doar Livro para Outro Leitor");
                Console.WriteLine("8. Pesquisar Livro por Título");
                Console.WriteLine("9. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine()!;
                try
                {
                    switch (opcao)
                    {
                        case "1": CadastrarLeitor(); break;
                        case "2": ListarLeitores(); break;
                        case "3": AdicionarLivro(); break;
                        case "4": ListarLivrosDeLeitor(); break;
                        case "5": EditarLivro(); break;
                        case "6": RemoverLivro(); break;
                        case "7": DoarLivro(); break;
                        case "8": PesquisarLivroPorTitulo(); break;
                        case "9": Console.WriteLine("Encerrando o programa..."); return;
                        default: Console.WriteLine("Opção inválida. Tente novamente."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        private static void CadastrarLeitor()
        {
            Console.Write("Nome do leitor: ");
            string nome = Console.ReadLine();
            Console.Write("CPF do leitor: ");
            string cpf = Console.ReadLine();
            Console.Write("Idade do leitor: ");
            int idade = int.Parse(Console.ReadLine());

            leitores.Add(new Leitor(nome, cpf, idade));
            Console.WriteLine("Leitor cadastrado com sucesso!");
        }

        private static void ListarLeitores()
        {
            Console.WriteLine("=== Lista de Leitores ===");
            foreach (var leitor in leitores)
            {
                Console.WriteLine($"Nome: {leitor.Nome}, CPF: {leitor.Cpf}, Idade: {leitor.Idade}");
            }
        }

        private static void AdicionarLivro()
        {
            Console.Write("CPF do leitor: ");
            string cpf = Console.ReadLine();

            var leitor = leitores.Find(l => l.Cpf == cpf);
            if (leitor == null) throw new ArgumentException("Leitor não encontrado.");

            Console.Write("Título do livro: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            Console.Write("Editora: ");
            string editora = Console.ReadLine();
            Console.Write("Ano de publicação: ");
            int ano = int.Parse(Console.ReadLine());
            Console.Write("Número de páginas: ");
            int paginas = int.Parse(Console.ReadLine());

            leitor.Livros.Add(new Livro(Guid.NewGuid().ToString(), titulo, "", autor, editora, "Gênero", ano, paginas, "Capa"));
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        private static void ListarLivrosDeLeitor()
        {
            Console.Write("CPF do leitor: ");
            string cpf = Console.ReadLine()!;

            var leitor = leitores.Find(l => l.Cpf == cpf);
            if (leitor == null) throw new ArgumentException("Leitor não encontrado.");

            Console.WriteLine($"Livros do leitor {leitor.Nome}:");
            foreach (var livro in leitor.Livros)
            {
                Console.WriteLine($"- {livro.Titulo}");
            }
        }

        private static void EditarLivro()
        {
            Console.Write("CPF do leitor: ");
            string cpf = Console.ReadLine()!;
            var leitor = leitores.Find(l => l.Cpf == cpf);
            if (leitor == null) throw new ArgumentException("Leitor não encontrado.");

            Console.Write("Título do livro a editar: ");
            string titulo = Console.ReadLine()!;

            var livro = leitor.Livros.Find(l => l.Titulo == titulo);
            if (livro == null) throw new ArgumentException("Livro não encontrado.");

            Console.Write("Novo título: ");
            livro.Titulo = Console.ReadLine()!;
            Console.WriteLine("Livro editado com sucesso!");
        }

        private static void RemoverLivro()
        {
            Console.Write("CPF do leitor: ");
            string cpf = Console.ReadLine()!;
            var leitor = leitores.Find(l => l.Cpf == cpf);
            if (leitor == null) throw new ArgumentException("Leitor não encontrado.");

            Console.Write("Título do livro a remover: ");
            string titulo = Console.ReadLine()!;

            var livro = leitor.Livros.Find(l => l.Titulo == titulo);
            if (livro == null) throw new ArgumentException("Livro não encontrado.");

            leitor.Livros.Remove(livro);
            Console.WriteLine("Livro removido com sucesso!");
        }

        private static void DoarLivro()
        {
            Console.Write("CPF do doador: ");
            string cpfDoador = Console.ReadLine()!;
            var doador = leitores.Find(l => l.Cpf == cpfDoador);
            if (doador == null) throw new ArgumentException("Doador não encontrado.");

            Console.Write("Título do livro a doar: ");
            string titulo = Console.ReadLine()!;

            var livro = doador.Livros.Find(l => l.Titulo == titulo);
            if (livro == null) throw new ArgumentException("Livro não encontrado no doador.");

            Console.Write("CPF do receptor: ");
            string cpfReceptor = Console.ReadLine()!;
            var receptor = leitores.Find(l => l.Cpf == cpfReceptor);
            if (receptor == null) throw new ArgumentException("Receptor não encontrado.");

            doador.Livros.Remove(livro);
            receptor.Livros.Add(livro);
            Console.WriteLine("Livro doado com sucesso!");
        }

        private static void PesquisarLivroPorTitulo()
        {
            Console.Write("Título do livro: ");
            string titulo = Console.ReadLine()!;

            foreach (var leitor in leitores)
            {
                var livro = leitor.Livros.Find(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));
                if (livro != null)
                {
                    Console.WriteLine($"Livro encontrado no leitor {leitor.Nome} (CPF: {leitor.Cpf})");
                    return;
                }
            }

            Console.WriteLine("Livro não encontrado.");
        }
    }
}
//Iago Henrique Schlemper
//Eduardo Da Silva Ramos