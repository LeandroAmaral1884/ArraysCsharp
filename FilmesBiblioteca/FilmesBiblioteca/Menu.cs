class Program
{
    static void Main()
    {

        FunctionMovie.CarregarDados();

        while (true)
        {
            Console.WriteLine("==== Streamberry ====");
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
            if (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("");
                Console.WriteLine("Opção inválida,digite um número!!!");
                Console.WriteLine("");
                continue;
            }

            switch (option)
            {
                case 1:
                    FunctionMovie.Cadastrar();
                    break;
                case 2:
                    FunctionMovie.Listar();
                    break;
                case 3:
                    FunctionMovie.Atualizar();
                    break;
                case 4:
                    FunctionMovie.Deletar();
                    break;
                case 5:
                    FunctionMovie.Pesquisar();
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
}