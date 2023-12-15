using System.Text.Json;

public class FunctionMovie
{
    private static List<Filme> acervo = new List<Filme>();
    private static string files = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "acervo.txt");

    public static void Listar()
    {
        acervo = CarregarDados();

        if (acervo.Count == 0)
        {
            Console.WriteLine("Nenhum filme encontrado.");
            return;
        }

        List<string> todosGeneros = CarregarGeneros();

        if (todosGeneros.Count == 0)
        {
            Console.WriteLine("Não há gêneros disponíveis.");
            return;
        }

        Console.WriteLine("");
        Console.WriteLine("Escolha um gênero para listar os filmes:");
        Console.WriteLine("");

        for (int i = 0; i < todosGeneros.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todosGeneros[i]}");
        }

        Console.WriteLine("");
        Console.Write("Digite o número do gênero desejado: ");
        if (int.TryParse(Console.ReadLine(), out int escolhaGenero) && escolhaGenero >= 1 && escolhaGenero <= todosGeneros.Count)
        {
            string generoEscolhido = todosGeneros[escolhaGenero - 1];

            Console.WriteLine("");
            Console.WriteLine($"Filmes do gênero {generoEscolhido}:");
            Console.WriteLine("");

            var filmesDoGenero = acervo.Where(f => f.Genero.Equals(generoEscolhido, StringComparison.OrdinalIgnoreCase)).ToList();

            if (filmesDoGenero.Count > 0)
            {
                int pageSize = 10;
                int totalPages = (int)Math.Ceiling((double)filmesDoGenero.Count / pageSize);
                int currentPage = 1;

                do
                {
                    Console.Clear();

                    var filmesPagina = filmesDoGenero.Skip((currentPage - 1) * pageSize).Take(pageSize);

                    Console.WriteLine($"Filmes do gênero {generoEscolhido}");
                    Console.WriteLine("");

                    foreach (var filme in filmesPagina)
                    {
                        Console.WriteLine($"Título: {filme.Titulo} - Ano de lançamento: {filme.Ano} - Avaliação: {filme.Avaliacao}");
                    }

                    Console.WriteLine("");
                    Console.WriteLine($"Página {currentPage}/{totalPages}:");
                    Console.WriteLine("");
                    Console.WriteLine("1 - Próxima página");
                    Console.WriteLine("2 - Página anterior");
                    Console.WriteLine("0 - Sair");

                    int opcaoPagina;
                    if (int.TryParse(Console.ReadLine(), out opcaoPagina))
                    {
                        switch (opcaoPagina)
                        {
                            case 1:
                                if (currentPage < totalPages)
                                {
                                    currentPage++;
                                }
                                break;
                            case 2:
                                if (currentPage > 1)
                                {
                                    currentPage--;
                                }
                                break;
                            case 0:
                                return;
                            default:
                                Console.WriteLine("");
                                Console.WriteLine("Opção inválida. Tente novamente.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine($"Nenhum filme cadastrado para o gênero {generoEscolhido}.");
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("");
            Console.WriteLine("Opção inválida. Tente novamente.");
        }

        Console.WriteLine("");
    }


    public static void Cadastrar()
    {
        Filme novoFilme = new Filme();
        List<string> generos = CarregarGeneros();

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
            Console.WriteLine("");
            Console.WriteLine("Escolha um gênero:");
            Console.WriteLine("");

            for (int i = 0; i < generos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {generos[i]}");
            }

            Console.WriteLine("");
            Console.Write("Digite uma opção de gênero: ");

            string opcaoGenero = Console.ReadLine()?.Trim();

            if (int.TryParse(opcaoGenero, out int indice) && indice >= 1 && indice <= generos.Count)
            {
                novoFilme.Genero = generos[indice - 1];
                break;
            }

            Console.WriteLine("Opção inválida. Escolha um número correspondente ao gênero.");

        } while (true);

        do
        {
            Console.Write("Ano: ");

            if (int.TryParse(Console.ReadLine()?.Trim(), out int ano) && ano >= 1930 && ano < 2024)
            {
                novoFilme.Ano = ano;
                break;
            }

            Console.WriteLine("Digite um ano válido entre 1930 e 2023.");

        } while (true);

        do
        {
            Console.Write("Avaliação: ");

            if (double.TryParse(Console.ReadLine()?.Trim(), out double avaliacao) && avaliacao >= 0 && avaliacao <= 10)
            {
                novoFilme.Avaliacao = avaliacao;
                break;
            }
            Console.WriteLine("Digite uma avaliação válida entre 0 e 10");
        } while (true);

        List<Filme> acervoAtual = CarregarDados();

        acervoAtual.Add(novoFilme);

        SalvarDados(acervoAtual);

        Console.WriteLine("");
        Console.WriteLine("Filme adicionado com sucesso!");
        Console.WriteLine("");
    }

    public static void Atualizar()
    {
        acervo = CarregarDados();

        Console.Write("Digite o título do filme que deseja atualizar: ");
        string titulo = Console.ReadLine();

        Filme filme = acervo.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (filme == null)
        {
            Console.WriteLine("");
            Console.WriteLine("Filme não encontrado.");
            Console.WriteLine("");
            return;
        }

        Console.WriteLine("");
        Console.Write($"Novo título ({filme.Titulo}) (ou Enter para manter a mesma): ");
        string novoTitulo = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoTitulo))
        {
            filme.Titulo = novoTitulo;
        }

        Console.WriteLine("");
        Console.Write("Escolha um novo gênero (ou Enter para manter o mesmo):\n");
        Console.WriteLine("");

        List<string> generos = CarregarGeneros();
        MostrarGeneros(generos);
        Console.WriteLine("");
        Console.Write("Digite o número correspondente ao novo gênero: ");
        string opcaoGenero = Console.ReadLine()?.Trim();

        if (int.TryParse(opcaoGenero, out int indice) && indice >= 1 && indice <= generos.Count)
        {
            filme.Genero = generos[indice - 1];
        }
        else
        {
            Console.WriteLine("Opção inválida. Mantendo o gênero atual.");
        }

        Console.WriteLine("");
        Console.Write($"Novo ano ({filme.Ano}) (ou Enter para manter a mesma): ");
        string novoAnoStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoAnoStr))
        {
            if (int.TryParse(novoAnoStr, out int novoAno) && novoAno >= 1930 && novoAno <= 2023)
            {
                filme.Ano = novoAno;
            }
            else
            {
                Console.WriteLine("Ano inválido. Mantendo o ano atual.");
            }
        }

        Console.WriteLine("");
        Console.Write($"Nova avaliação (ou Enter para manter a mesma): ");
        string novaAvaliacaoStr = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novaAvaliacaoStr))
        {
            if (double.TryParse(novaAvaliacaoStr, out double novaAvaliacao) && novaAvaliacao >= 0 && novaAvaliacao <= 10)
            {
                filme.Avaliacao = novaAvaliacao;
            }
            else
            {
                Console.WriteLine("Avaliação inválida. Mantendo a avaliação atual.");
            }
        }

        Console.WriteLine("");
        Console.WriteLine("Filme atualizado com sucesso!");
        Console.WriteLine("");

        SalvarDados(acervo);
    }

    public static void Deletar()
    {
        Console.Write("Digite o título do filme que deseja deletar: ");
        string titulo = Console.ReadLine();

        Filme filme = acervo.FirstOrDefault(f => f.Titulo.Trim().Equals(titulo.Trim(), StringComparison.OrdinalIgnoreCase));

        if (filme == null)
        {
            Console.WriteLine("");
            Console.WriteLine("Filme não encontrado.");
            Console.WriteLine("");
            return;
        }
        acervo.Remove(filme);

        SalvarDados(acervo);
        Console.WriteLine("");
        Console.WriteLine("Filme deletado com sucesso!");
        Console.WriteLine("");
    }



    public static void Pesquisar()
    {
        acervo = CarregarDados();
        Console.WriteLine("");
        Console.Write("Digite o título do filme que deseja pesquisar: ");
        string titulo = Console.ReadLine();

        Filme filme = acervo.FirstOrDefault(f => f.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (filme == null)
        {
            Console.WriteLine("");
            Console.WriteLine("Filme não encontrado.");
            Console.WriteLine("");
            return;
        }
        Console.WriteLine("");
        Console.WriteLine($"Filme encontrado: Título: {filme.Titulo} - Gênero: {filme.Genero} - Ano de lançamento: {filme.Ano} - Avaliação: {filme.Avaliacao}");
        Console.WriteLine("");
    }

    public static List<string> CarregarGeneros()
    {
        return new List<string> {
        "Ação",
        "Comédia",
        "Drama",
        "Espiritual",
        "Ficção Científica",
        "Romance",
        "Suspense",
        "Terror",
        "Aventura",
        "Animação",
        "Documentário",
        "Fantasia",
        "Musical",
        "Mistério",
        "Crime",
        "Histórico",
        "Outros"
    };
    }

    public static void MostrarGeneros(List<string> generos)
    {
        for (int i = 0; i < generos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {generos[i]}");
        }
    }

    public static List<Filme> CarregarDados()
    {

        if (File.Exists(files))
        {
            string conteudoAtual = File.ReadAllText(files);
            return JsonSerializer.Deserialize<List<Filme>>(conteudoAtual);
        }
        return new List<Filme>();
    }



    public static void SalvarDados(List<Filme> acervoAtual)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        string json = JsonSerializer.Serialize(acervoAtual, options);
        File.WriteAllText(files, json);
    }
}