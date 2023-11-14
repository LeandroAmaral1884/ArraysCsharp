using System.ComponentModel.Design;
using System.Threading.Channels;

Console.WriteLine("## Classe Array ##\n");
string[] nomes = { "Pedro", "Maria", "José", "Mario", "Lucas" };

Console.WriteLine("## Exibindo Array original ##\n");
ExibirArray(nomes);

Console.WriteLine("\n\n## Invertendo Array  ##\n");
Array.Reverse(nomes);
ExibirArray(nomes);

Console.WriteLine("\n\n## Ordenado Array  ##\n");
Array.Sort(nomes);
ExibirArray(nomes);


Console.WriteLine("\n\n## Encontrar o nome Array  ##\n");
Console.WriteLine("\n Informe nome:\n");

string nome= Console.ReadLine();

var indice = Array.BinarySearch(nomes,nome);
if (indice >= 0)

    Console.WriteLine($"{nome} foi encotrado com indice =  {indice}");

else Console.WriteLine($"{nome} Não foi encotrado");



Console.ReadLine();

static void ExibirArray(string[] nomes)
{
    foreach (string nome in nomes)
    {
        Console.Write($"{nome} ");
    }
}