using System;

class Program
{
    static void Main(string[] args)
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
