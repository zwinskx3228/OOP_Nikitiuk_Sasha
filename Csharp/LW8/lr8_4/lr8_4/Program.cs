using lr8_4;
using System;

class Program
{
    static void Main()
    {
        // int
        Console.Write("Enter integer number: ");
        int intValue = int.Parse(Console.ReadLine());

        Console.WriteLine($"Is {intValue} even? =  {intValue.IsEven()}");
        Console.WriteLine();

        // double
        Console.Write("Enter double number: ");
        double doubleValue = double.Parse(Console.ReadLine());

        Console.WriteLine($"Rounded to 2 digits: {doubleValue.Round2()}");
        Console.WriteLine();

        // string
        Console.Write("Enter text: ");
        string inputText = Console.ReadLine();

        Console.WriteLine($"Capitalized: {inputText.Capitalize()}");
        Console.WriteLine();

        Console.WriteLine("Done!");
    }
}