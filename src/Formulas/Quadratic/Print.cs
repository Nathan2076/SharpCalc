using System;
using SharpCalc.Utilities;        // PrintFraction.cs and RemoveDecimals.cs
using static Quadratic.Values;    // Values.cs
using static Formulas.Quadratic;  // Quadratic.cs

namespace Quadratic
{
    class StepByStep
    {
        public static void Print(Coefficient coefficient)
        {
            var discriminant = result.discriminant;

            string a = coefficient.a < 0 ? $"({coefficient.a})" : $"{coefficient.a}";
            string b = coefficient.b < 0 ? $"({coefficient.b})" : $"{coefficient.b}";
            string c = coefficient.c < 0 ? $"({coefficient.c})" : $"{coefficient.c}";
            string d = config["sbs:discriminant:symbol"];

            var denominator = 2 * coefficient.a;

            if (bool.Parse(config["sbs:discriminant:separated"]))
            {
                Print(coefficient, d);

                Console.WriteLine("     -b ± √{0}\n" +
                                  "x = ─────────\n" +
                                  "       2a\n", d);
            }
            else
            {
                Console.WriteLine($"\n     -b ± √[b² - 4ac]\n" +
                                     "x = ──────────────────\n" +
                                     "            2a\n");

                Fraction.PrintFraction($"-{b} ± √[{b}² - 4 × {a} × {c}]", $"2 × {a}", "x");

                if (4 * coefficient.a * coefficient.c < 0)
                {
                    Fraction.PrintFraction($"-{b} ± √[{Math.Pow(coefficient.b, 2)} - ({4 * coefficient.a * coefficient.c})]",
                                           $"{denominator}", "x");

                    Fraction.PrintFraction($"-{b} ± √[{Math.Pow(coefficient.b, 2)} + {-(4 * coefficient.a * coefficient.c)}]",
                                           $"{denominator}", "x");
                }
                else
                {
                    Fraction.PrintFraction($"-{b} ± √[{Math.Pow(coefficient.b, 2)} - {4 * coefficient.a * coefficient.c}]",
                                           $"{denominator}", "x");
                }
            }

            Fraction.PrintFraction($"-{b} ± √{discriminant}", $"{denominator}", "x");

            if (!(result.imaginary < 0))
            {
                Fraction.PrintFraction($"-{b} ± {Math.Sqrt(discriminant)}", $"{denominator}", "x");

                if (discriminant != 0)
                {
                    Fraction.PrintFraction($"-{b} + {Math.Sqrt(discriminant)}", $"{denominator}", "x₁");

                    Fraction.PrintFraction($"{-coefficient.b + Math.Sqrt(discriminant)}", $"{denominator}", "x₁");

                    Console.WriteLine($"x₁ = {result.first}\n");

                    Fraction.PrintFraction($"-{b} - {Math.Sqrt(discriminant)}", $"{denominator}", "x₂");

                    Fraction.PrintFraction($"{-coefficient.b - Math.Sqrt(discriminant)}", $"{denominator}", "x₂");

                    Console.WriteLine($"x₂ = {result.second}\n");
                }
                else
                {
                    Fraction.PrintFraction($"-{b}", $"{denominator}", "x");

                    Console.WriteLine($"x = {-coefficient.b / denominator}");
                }
            }
            else
            {

            }
        }

        public static void Print(Coefficient coefficient, string d)
        {
            double a = coefficient.a,
                   b = coefficient.b,
                   c = coefficient.c;

            var discriminant = result.discriminant;

            Console.WriteLine($"\n{d} = b² - 4ac");

            PrintDiscriminant(coefficient, d);

            if (4 * a * c < 0)
            {
                Console.WriteLine($"{d} = {Math.Pow(b, 2)} - ({4 * a * c})\n" +
                                  $"{d} = {Math.Pow(b, 2)} + {-(4 * a * c)}");
            }
            else
            {
                Console.WriteLine($"{d} = {Math.Pow(b, 2)} - {4 * a * c}");
            }

            Console.WriteLine($"{d} = {discriminant}\n");
        }

        static void PrintDiscriminant(Coefficient coefficient, string d)
        {
            string a = coefficient.a < 0 ? $"({coefficient.a})" : $"{coefficient.a}";
            string b = coefficient.b < 0 ? $"({coefficient.b})²" : $"{coefficient.b}²";
            string c = coefficient.c < 0 ? $"({coefficient.c})" : $"{coefficient.c}";

            Console.WriteLine("{3} = {1} - 4 × {0} × {2}", a, b, c, d);
        }
    }
}