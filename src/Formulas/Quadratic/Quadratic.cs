using System;
using Microsoft.Extensions.Configuration;
using SharpCalc.Utilities;      // Decimals.cs
using Quadratic;                // Print.cs
using static Quadratic.Values;  // Values.cs

namespace Formulas
{
    class Quadratic
    {
        public static Result result = new();

        public static IConfiguration config = new ConfigurationBuilder().AddJsonFile("Configs/config.quadratic.json").Build();

        public static void Run()
        {
            Console.Title = "Quadratic Equation - SharpCalc";

            var coefficient = InputUserCoefficient();
            var result = CalculateSolutions(coefficient);

            if (bool.Parse(config["sbs:enabled"]))
            {
                StepByStep.Print(coefficient);
            }

            PrintSolutions(coefficient);
        }

        static Coefficient InputUserCoefficient()
        {
            Console.WriteLine("\nEnter the values (a, b, c).");

            try
            {
                double a = double.Parse(Console.ReadLine()),
                       b = double.Parse(Console.ReadLine()),
                       c = double.Parse(Console.ReadLine());

                return new() { a = a, b = b, c = c };
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nThat's not a number. Type again. | " + ex.Message);
            }

            Console.WriteLine();

            return new() { a = 0, b = 0, c = 0 };
        }

        static Result CalculateSolutions(Coefficient coefficient)
        {
            result.discriminant = Math.Pow(coefficient.b, 2) - (4 * coefficient.a * coefficient.c);

            if (result.discriminant >= 0)
            {
                result.first = (-coefficient.b + Math.Sqrt(result.discriminant)) / (2 * coefficient.a);
                result.second = (-coefficient.b - Math.Sqrt(result.discriminant)) / (2 * coefficient.a);
            }
            else
            {
                result.imaginary = -result.discriminant;
            }

            return result;
        }

        static void PrintSolutions(Coefficient coefficient)
        {
            if (Double.IsNaN(Math.Sqrt(-result.imaginary)))
            {
                Console.WriteLine("\nx = {0} ± {1}i\n",
                                  Decimals.RemoveExcessiveDecimals(-coefficient.b / (2 * coefficient.a)),
                                  Decimals.RemoveExcessiveDecimals(Math.Sqrt(result.imaginary) / (2 * coefficient.a)));
            }
            else
            {
                if (result.first != result.second)
                {
                    Console.WriteLine("\nS = {{{0}; {1}}}\n", Decimals.RemoveExcessiveDecimals(result.first),
                                                              Decimals.RemoveExcessiveDecimals(result.second));
                }
                else
                {
                    Console.WriteLine("\nS = {{{0}}}\n", Decimals.RemoveExcessiveDecimals(-coefficient.b / (2 * coefficient.a)));
                }
            }
        }
    }
}