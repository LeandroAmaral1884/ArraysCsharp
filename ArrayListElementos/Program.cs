using System.Collections;

Console.WriteLine("Array List Elementos\n");

var lista = new ArrayList() { "Maria", 5, true, "", null };

//   0    1   2   3  4
lista.Add(3.5);

lista.Insert(2, "Paulo");

var lista2 = new ArrayList() { "Maria", 5, true };
Console.WriteLine("\nArray List adicionando coleção\n");
int[] array1 = { 1, 2, 3, };

lista2.AddRange(array1);

Console.ReadLine();
