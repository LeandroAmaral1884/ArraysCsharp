using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Filme> acervo = new List<Filme>();
    static string files = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "acervo.txt");

    static void Main()
    {
        CarregarDados();

        while (true)
        {
            Console.WriteLine("==== Streambewrry ====");
            Console.WriteLine("");

            Console.WriteLine("Digite o número da opção desejada:");
            Console.WriteLine("");

            Console.WriteLine("1. Cadastrar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Atualizar");
            Console.WriteLine("4. Deletar");
            Console.WriteLine("5. Pesquisar");
            Console.WriteLine("6. Sair");
            Console.WriteLine("");


            int option;
            if (!int.TryParse(Console.ReadLine(), out option)){
                Console.WriteLine("");
                Console.WriteLine("Opção inválida,digite um número!!!");
                Console.WriteLine("");
                continue;
            }
           

            switch (option)
            {
              
                case 1:
                    Cadastrar();
                    break;

                case 2:
                    Listar();
                    break;
                case 3:
                    Atualizar();
                    break;
                case 4:
                    Deletar();
                    break;
                case 5:
                    Pesquisar();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void Listar()
    {
        if (acervo.Count == 0)
        {
            Console.WriteLine("Nenhum filme encontrado.");
            return;
        }

        Console.WriteLine("Lista de Filmes:");
        foreach (var filme in acervo)
        {
            Console.WriteLine($"{filme.Titulo} - {filme.Genero} - {filme.Ano} - Avaliação: {filme.Avaliacao}");
        }
    }

    static void Cadastrar()
    {
        Filme novoFilme = new Filme();

        do
        {
            Console.Write("Título: ");
            novoFilme.Titulo = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(novoFilme.Titulo))
            {
                Console.WriteLine("Digite um título válido");
            }
        } while (string.IsNullOrEmpty(novoFilme.Titulo));

        do
        {
            Console.Write("Gênero: ");
            novoFilme.Genero = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(novoFilme.Genero))
            {
                Console.WriteLine("Digite um gênero válido");
            }
        } while (string.IsNullOrEmpty(novoFilme.Genero));

        do
        {
            Console.Write("Ano: ");
         
            if (int.TryParse(Console.ReadLine()?.Trim(), out int ano) && ano > 0)
            {
                novoFilme.Ano = ano;
                break;
            }
            Console.WriteLine("Digite um ano válido");
        } while (true);

        do
        {
            Console.Write("Avaliação: ");
         
            if (double.TryParse(Console.ReadLine()?.Trim(), out double avaliacao) && avaliacao > 0)
            {
                novoFilme.Avaliacao = avaliacao;
                break;
            }
            Console.WriteLine("Digite uma avaliação válida");
        } while (true);

      

        acervo.Add(novoFilme);
        Console.WriteLine("Filme adicionado com sucesso!");

        SalvarDados();

    }

    static void Atualizar()
    {
        Console.Write("Digite o título do filme que deseja atualizar: ");
        string titulo = Console.ReadLine();

        Filme filme = acervo.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (filme == null)
        {
            Console.WriteLine("Filme não encontrado.");
            return;
        }

        Console.Write("Novo título (ou Enter para manter o mesmo): ");
        string novoTitulo = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoTitulo))
        {
            filme.Titulo = novoTitulo;
        }

        Console.Write("Novo gênero (ou Enter para manter o mesmo): ");
        string novoGenero = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoGenero))
        {
            filme.Genero = novoGenero;
        }

        Console.Write("Novo ano (ou Enter para manter o mesmo): ");
        string novoAnoStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoAnoStr))
        {
            int novoAno;
            if (int.TryParse(novoAnoStr, out novoAno))
            {
                filme.Ano = novoAno;
            }
            else
            {
                Console.WriteLine("Ano inválido. Mantendo o ano atual.");
            }
        }

        Console.Write("Nova avaliação (ou Enter para manter a mesma): ");
        string novaAvaliacaoStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novaAvaliacaoStr))
        {
            double novaAvaliacao;
            if (double.TryParse(novaAvaliacaoStr, out novaAvaliacao))
            {
                filme.Avaliacao = novaAvaliacao;
            }
            else
            {
                Console.WriteLine("Avaliação inválida. Mantendo a avaliação atual.");
            }
        }

        Console.WriteLine("Filme atualizado com sucesso!");

        SalvarDados();
    }

    static void Deletar()
    {
        Console.Write("Digite o título do filme que deseja deletar: ");
        string titulo = Console.ReadLine();

        Filme filme = acervo.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (filme == null)
        {
            Console.WriteLine("Filme não encontrado.");
            return;
        }

        acervo.Remove(filme);
        Console.WriteLine("Filme deletado com sucesso!");

        SalvarDados();
    }

    static void Pesquisar()
    {
        Console.Write("Digite o título do filme que deseja pesquisar: ");
        string titulo = Console.ReadLine();

        Filme filme = acervo.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (filme == null)
        {
            Console.WriteLine("Filme não encontrado.");
            return;
        }

        Console.WriteLine($"Filme encontrado: {filme.Titulo} - {filme.Genero} - {filme.Ano} - Avaliação: {filme.Avaliacao}");
    }

    static void CarregarDados()
    {
        if (File.Exists(files))
        {
            string[] linhas = File.ReadAllLines(files);

            foreach (var linha in linhas)
            {
                string[] dados = linha.Split(',');
                if (dados.Length == 4)
                {
                    Filme filme = new Filme
                    {
                        Titulo = dados[0],
                        Genero = dados[1],
                        Ano = int.Parse(dados[2]),
                        Avaliacao = double.Parse(dados[3])
                    };
                    acervo.Add(filme);
                }
            }
        }
    }

    static void SalvarDados()
    {
        using (StreamWriter sw = new StreamWriter(files))
        {
            foreach (var filme in acervo)
            {
                sw.WriteLine($"{filme.Titulo},{filme.Genero},{filme.Ano},{filme.Avaliacao}");
            }
        }
    }
}

