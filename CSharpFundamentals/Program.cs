using System;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int a=4;
            Console.WriteLine("The number is: "+ a);
            String name = "Juanito";
            Console.WriteLine("The name is: " + name);
            Console.WriteLine($"The name is {name}");   // ejecucion con validacion muy importante
            var age = "23";                             // Tipo de dato variable se adapta dependiendo que recibe
            Console.WriteLine("Age is " + age);
            // si asigno un tipo de dato diferente para age generara error.
            dynamic height =13.2;
            Console.WriteLine($"Height is {height}");
            height = "hello"; // Dynamic si permite un cambio de tipo de data.
            Console.WriteLine($"Height is {height}");
        }
    }
}
