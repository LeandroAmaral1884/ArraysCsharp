Console.WriteLine("## Exercicio Array ##\n");

string[] nomes = new string[5];
double[] notas  = new double[5];

Console.WriteLine("## Alunos ##\n");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Digite nomes {i}:");
    string ?nome = Console.ReadLine();
    nomes[i] = nome;

}


Console.WriteLine("## Notas ##\n");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Digite nomes {i}:");
    double nota =Convert.ToDouble(Console.ReadLine());
    notas[i] = nota;

}

foreach (string  nome in nomes)
{
    Console.Write($"{nome} ");
}

var somaNotas = 0.0;
var totalNotas=notas.Count();
foreach (double nota in notas)
{
    somaNotas += nota;
    Console.Write($"{nota} ");
}

Console.WriteLine($"\n Media das notas = {somaNotas/totalNotas}");

Console.ReadLine();
