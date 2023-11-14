Console.WriteLine("## Arrays For ##\n");

// declração do array

int[] numeros;

//alocado a memoria
// indice               0  1  2  3  4  5  6  7  8  9
numeros = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

// indice            0         1        2       3        4     
string[] nomes = { "Pedro", "Maria", "José", "Mario", "Lucas" };

Console.WriteLine(nomes[0]);
Console.WriteLine(nomes[1]);
Console.WriteLine(nomes[2]);
Console.WriteLine(nomes[3]);
Console.WriteLine(nomes[4]);


// declração do array
int[] numeros1;
//alocado a memoria
numeros1 = new int[3];

numeros1[0] = 1;
numeros1[1] = 2;
numeros1[2] = 3;

Console.ReadKey();