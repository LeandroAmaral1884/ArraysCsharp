Console.WriteLine("Params aplicação \n");

int[] n= { 1, 2, 3, 4, 5, 6, 7, 8 };

Console.WriteLine($"{Calcular.Somar(n)}\n");

Console.WriteLine("Params\n");

Console.WriteLine($"{Calcular.Somar(1,2,3,4,5,6,7,8)}");

Console.ReadKey();


public class Calcular
{

    public  static int Somar( params int[] numeros)
    {
        int total = 0;
        foreach (int numero in numeros)
        {
            total += numero;
        }
        return total;
    }
}
