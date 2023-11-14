Console.WriteLine("## Foreach ##\n");

int[] numeros;

//alocado a memoria
// indice               0  1  2  3  4  5  6  7  8  9
numeros = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

string[] nomes = { "Pedro", "Maria", "José", "Mario", "Lucas" };

foreach (int numero in numeros)
{
    Console.Write($"{numero}  ");
}

foreach (string nome in nomes)
{
    Console.Write($"{nome} ");
}

Console.ReadLine();