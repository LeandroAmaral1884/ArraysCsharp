
//declarei e aloquei memoria para array
string[,] alunos = new string[2,5];
Console.WriteLine("\n Atribuindo dados a um Array de" +
    "string com 2 linhas e 5 colunas[2,5]");
Console.WriteLine("\n{Maria,Paulo,Marta,Pedro,Carlos}");
Console.WriteLine("{Silvia,Paulo,Alicia,Manoel,Paula}");

for (int i = 0; i < alunos.GetLength(0); i++)
{
    for (int j = 0; j < alunos.GetLength(1); j++)
    {
        Console.WriteLine($"informe o valor para o elemento na posilção [{i} , {j}]");
        alunos  [i,j] = Console.ReadLine();
    }
}

Console.WriteLine("\nConteudo do Array Alunos");
for (int i = 0; i < alunos.GetLength(0); i++)
{
    for (int j = 0; j < alunos.GetLength(1); j++)
    {
        Console.Write($"[{i},{j}] = {alunos[i,j]}");
    }
    Console.WriteLine();
}

Console.ReadLine();