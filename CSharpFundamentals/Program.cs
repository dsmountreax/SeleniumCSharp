﻿using System;

namespace CSharpFundamentals
{
    class Program : Program4
    {
        String name;
        String lastName;

        // method default constructor

        public Program(String name)
        {
            this.name = name;
        }

        public Program(String name, String lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        public void getName()
        {
            Console.WriteLine("My name is "+this.name);
        }
        public void getData()
        {
            Console.WriteLine("I am inside the method");
        }
        static void Main(string[] args)
        {

            Program p = new Program("Rahul");
            Program p1 = new Program("Enrique", "Oreiro");
            p.getData();
            p.getName();
            p.setData();

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
