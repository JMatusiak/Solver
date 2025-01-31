using System;

namespace QuadraticEquation
{
    public class EquationSolver
    {
        public static (double[] Roots, string Message) ComputeRoots(double a, double b, double c)
        {
            if (a == 0)
                throw new ArgumentException("Wartość 'a' nie może być równa zero.");

            double delta = Math.Pow(b, 2) - 4 * a * c;

            if (delta < 0)
                return (Array.Empty<double>(), "Brak rzeczywistych pierwiastków.");

            if (delta == 0)
                return (new double[] { -b / (2 * a) }, "Jedno rozwiązanie rzeczywiste.");

            double sqrtDelta = Math.Sqrt(delta);
            return (new double[] { (-b + sqrtDelta) / (2 * a), (-b - sqrtDelta) / (2 * a) }, "Dwa rozwiązania rzeczywiste.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Podaj współczynniki równania kwadratowego (ax² + bx + c = 0):");

            Console.Write("a: ");
            double coefficientA = Convert.ToDouble(Console.ReadLine());

            Console.Write("b: ");
            double coefficientB = Convert.ToDouble(Console.ReadLine());

            Console.Write("c: ");
            double coefficientC = Convert.ToDouble(Console.ReadLine());

            try
            {
                var (roots, message) = EquationSolver.ComputeRoots(coefficientA, coefficientB, coefficientC);
                Console.WriteLine(message);

                if (roots.Length > 0)
                {
                    Console.WriteLine("Pierwiastki:");
                    foreach (var root in roots)
                    {
                        Console.WriteLine(root);
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Błąd: {error.Message}");
            }
        }
    }
}
