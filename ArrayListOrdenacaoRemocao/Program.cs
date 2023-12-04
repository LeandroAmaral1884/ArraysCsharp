using System.Collections;

var lista = new ArrayList() { "maria",5,true,4.5,null,DateTime.Now };
var lista1 = new ArrayList() { "maria","Pedro","Leandro","marcos","mariza","pedro" };

//vereficar se um elemento existe na coleção

var res1 =lista.Contains(5);//true
bool res2 =lista.Contains("mari");//false

Console.WriteLine(res1);
Console.WriteLine(res2);
Console.WriteLine(lista.Contains(null));//true


Console.WriteLine("\n ArrayList Original \n");
foreach (var item in lista1)
{
    Console.Write($"{item} ");
}
lista1.Sort();
Console.WriteLine("\n\n ArrayList Ordenada \n");
foreach (var item in lista1)
{
    Console.Write($"{item} ");
}
Console.WriteLine("\n Numero de elementos no array " + lista1.Count);
lista1.Clear();
Console.WriteLine("\n Numero de elementos no array do Clear " + lista1.Count);

Console.ReadLine();
