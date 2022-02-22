using System;

class Program
{
    static void Main(string[] args)
    {
        double a, b, c;

        Console.Write("a = ");
        a = Convert.ToDouble(Console.ReadLine());

        Console.Write("b = ");
        b = Convert.ToDouble(Console.ReadLine());

        Console.Write("c = ");
        c = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"({a})x^2 + ({b})x + ({c}) = 0");
        double d = Math.Pow(b, 2) - 4 * a * c;
        if (d > 0)
        {
            double x1, x2;
            x1 = (-b + Math.Sqrt(d)) / (2 * a);
            x2 = (-b - Math.Sqrt(d)) / (2 * a);
            Console.WriteLine($"x1 = {x1}\nx2 ={x2}");
        }
        else if (d == 0)
        {
            double x1;
            x1 = -b / (2 * a);
            Console.WriteLine(x1);
        }
        else
        {
            Console.WriteLine("No roots");
        }
    }
}