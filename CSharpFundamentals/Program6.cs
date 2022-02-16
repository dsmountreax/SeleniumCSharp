using System;
using System.Collections;

ArrayList a = new ArrayList();
a.Add("Hello");
a.Add("Bye");
a.Add("Rahul");
a.Add("Apple");

foreach(String item in a)
{
    Console.WriteLine(item);
}

Console.WriteLine(a.Contains("Rahul"));
a.Sort();
Console.WriteLine("After Sorting");

foreach (String item in a)
{
    Console.WriteLine(item);
}
