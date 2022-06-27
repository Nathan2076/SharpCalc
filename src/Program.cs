using System;

namespace SharpCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SharpCalc";

            Console.WriteLine("Welcome to SharpCalc. Type \"h\" for help, or \"q\" to quit.\n");

            string input = Console.ReadLine().ToLower();

            while (input != "q" || input != "quit")
            {

                switch (input)
                {
                    case "quadratic":
                        Formulas.Quadratic.Run();
                        break;
                    case "quadratic settings":
                        Quadratic.Settings.ListSettings();
                        break;
                    case "s":  case "settings":
                    case "o":  case "options":
                        Settings.ListSettings();
                        break;
                    case "h":  case "help":
                        ListHelp();
                        break;
                    case "q":  case "quit":
                        return;
                }

                Console.Title = "SharpCalc";

                input = Console.ReadLine().ToLower();
            }
        }

        static void ListHelp()
        {
            Console.WriteLine("\nSharpCalc v0.0.1\n");
            Console.WriteLine("Formulas:");
            Console.WriteLine("  quadratic      Solves the quadatic equation (ax² + bx + c = 0).");
            Console.WriteLine();
        }
    }
}
