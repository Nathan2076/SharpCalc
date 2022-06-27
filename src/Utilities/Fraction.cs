using System;

namespace SharpCalc.Utilities
{
    class Fraction
    {
        public static void PrintFraction(string numerator, string denominator, string x = "")
        {
            if (x != "")
            {
                for (int i = 0; i <= x.Length + 3; i++)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(numerator);

            if (x != "") { Console.Write($"{x} = "); }

            for (int i = 0; i <= numerator.Length + 1; i++)
            {
                Console.Write('─');
            }

            Console.WriteLine();

            if (x != "")
            {
                for (int i = 0; i <= x.Length + 3; i++)
                {
                    Console.Write(" ");
                }
            }
            else
            {
                Console.Write(" ");
            }

            var spaces = numerator.Length % 2 == 0
                       ? (numerator.Length / 2) - denominator.Length
                       : (numerator.Length / 2) - Math.Floor(Convert.ToDouble(denominator.Length / 2));

            if (numerator.Length % 2 == 0)
            {
                for (int i = 0; i <= spaces; i++) { Console.Write(" "); }
            }
            else
            {
                for (int i = 0; i <= spaces; i++) { Console.Write(" "); }
            }

            Console.WriteLine(denominator + '\n');
        }
    }
}