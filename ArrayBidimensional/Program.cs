Console.WriteLine(" Array Bidimesional \n");


Console.WriteLine("\nInicializalção");
/*int[,] numeros;//numeros -> null
numeros = new int[2, 3]; // atribui os valortes padrão [0,0,0] ALOCA MEMÓRIA
                         // [0,0,0} ALOCA MEMÓRIA
numeros = new int[2, 3]{  { 1, 2, 3 }, // mumeros[0,1] mumeros[0,2] mumeros[0,3] INICIALIZAÇÃO
                          { 4, 5, 6 }};// mumeros[1,1] mumeros[2,2] mumeros[3,3] INICIALIZAÇÃO
OU*/
    int [,] numeros = new int[2,3]{ { 1, 2, 3 }, 
                                    { 4, 5, 6 }};
/*numeros[0,1]=0
numeros[0,2]=1
numeros[0,3]=2
numeros[1,1]=3
numeros[1,2]=4
numeros[1,3]=5*/

foreach (int numero in numeros)
{
    Console.Write($"{numero} ");

}


int[,] n = { {11,22,33}, // n[0,0] n[0,1] n[0,2]
             {44,55,66}, // n[1,0] n[1,1] n[1,2]   n[3,3]  -> n[i,j]
             {77,88,99 } // n[2,0] n[2,1] n[2,2]
};

Console.Write($"\nFor \n");

for (int i = 0; i < n.GetLength(0); i++)

{

    for (int j = 0; j < n.GetLength(1); j++)
    {
        Console.Write($"{n[i, j]} ");
    }
    Console.WriteLine();
}

Console.WriteLine("\nForeach");

foreach (var item in n)
{
    Console.Write(item);
}





Console.ReadKey();