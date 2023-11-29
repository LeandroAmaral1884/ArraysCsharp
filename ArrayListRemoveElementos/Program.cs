using System.Collections;

var lista = new ArrayList() { "Paulo", 5, true, "", null, 1.1, "Zé", 3, 9, null };


lista.Remove(null);
lista.RemoveAt(4);
lista.RemoveRange(0, 2);

Console.ReadLine();
