Console.WriteLine("## Arrays ##\n");

// declração do array

int[] numeros;

//alocado a memoria.
// indice               0  1  2  3  4  5  6  7  8  9
numeros = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// indice            0         1        2       3        4     
string[] nomes = { "Pedro", "Maria", "José", "Mario", "Lucas" };

// estrutura do for
for (int i = 0; i < numeros.Length; i++) {
    Console.WriteLine($"Elemento do valor do indice {i} : {numeros[i]}");
}
for (int i = 0; i < nomes.Length; i++)
{
    Console.WriteLine($"Elemento do valor do indice {i} : {nomes[i]}");
}
Console.ReadKey();