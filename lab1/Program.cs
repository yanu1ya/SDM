using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Choose the mode (interactive: 0, non-interactive: 1): ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "0":
                interactiveMode();
                break;
            case "1":
                nonInteractiveMode();
                break;
            default:
                Console.WriteLine("*-*");
                break;
        }
    }
    static void interactiveMode()
    {
        double a, b, c;
        Console.WriteLine("You've chosen interactive mode.\nInput your numbers, please.");
        a = inputCorrectNumber("a");
        if (a == 0) // exception
        {
            Console.WriteLine("Error: a can't be equal to 0. Try again.");
            a = inputCorrectNumber("a");
        }

        b = inputCorrectNumber("b");

        c = inputCorrectNumber("c");

        Console.WriteLine($"({a})x^2 + ({b})x + ({c}) = 0");

        findRoots(a, b, c);
    }
    static void nonInteractiveMode()
    {
        Console.Write("You've chosen non-interactive mode.\nInput file path here, please: ");
        string path = Console.ReadLine();
        if (File.Exists(path))
        {
            string result = File.ReadAllText(@path);
            // path format has to be like this: "E:\storage\C#\1\coefs.txt"
            string pattern = @"-?\d(\,\d*)? -?\d(\,\d*)? -?\d(\,\d*)?
";
            bool isMatch = Regex.IsMatch(result, pattern);
            if (isMatch)
            {
                string[] numbers = result.Split(' ');
                findRoots(Convert.ToDouble(numbers[0]), Convert.ToDouble(numbers[1]), Convert.ToDouble(numbers[2]));
            }
            else
            {
                Console.WriteLine("nop");
            }
        }
        else
        {
            Console.WriteLine("Error: Wrong path.");
        }
    }
    static void findRoots(double a, double b, double c)
    {
        double d = Math.Pow(b, 2) - 4 * a * c; // discriminant 
        if (d > 0)
        {
            double x1, x2;
            x1 = (-b + Math.Sqrt(d)) / (2 * a);
            x2 = (-b - Math.Sqrt(d)) / (2 * a);
            Console.WriteLine($"There are 2 roots:\nx1 = {x1}\nx2 = {x2}");
        }
        else if (d == 0)
        {
            double x1;
            x1 = -b / (2 * a);
            Console.WriteLine($"There is 1 root:\n{x1}");
        }
        else
        {
            Console.WriteLine("No roots found.");
        }
    }
    static double inputCorrectNumber(string letter)
    {
        double i = 0;
        Console.Write($"{letter}: ");
        string test = Console.ReadLine();
        if (double.TryParse(test, out i)) // tries if test can be parsed into double, if true - result goes to variable i
        {
            // i = Convert.ToDouble(test);
            return i;
        }
        else
        {
            Console.WriteLine("Eror: Entered value isn't considered a number. Try again.");
            return inputCorrectNumber(letter);
        }
    }
}

