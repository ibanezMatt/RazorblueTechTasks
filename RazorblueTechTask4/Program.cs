using System;
using System.Linq;

namespace RazorblueTechTask4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running FizzBuzz program");

            // run a loop for each int from 1 through to 100
            Enumerable.Range(1, 100).ToList()
                .ForEach(i =>
                {
                    Console.WriteLine(i.FizzBuzzValidation());
                });

            Console.WriteLine("Program complete, press enter to exit");
            Console.ReadKey();
        }
    }
}
