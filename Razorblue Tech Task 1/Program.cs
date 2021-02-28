using System;

namespace RazorblueTechTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your first word:");
            string firstValue = Console.ReadLine();

            Console.WriteLine("Enter your second word:");
            string secondValue = Console.ReadLine();

            Console.WriteLine($"{firstValue.IsAnagramOf(secondValue)}: {secondValue} is an anagram of {firstValue} \r\n");

            Console.WriteLine("Press the enter key to exit.");
            Console.ReadKey();
        }
    }
}
