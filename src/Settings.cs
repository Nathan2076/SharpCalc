using System;
using SharpCalc.Utilities;  // Configs.cs

namespace SharpCalc
{
    class Settings
    {
        public static void ListSettings()
        {
            Console.Title = "Settings - SharpCalc";

            Console.WriteLine("\nSharpCalc Settings:");
            Console.WriteLine("  decimal precision      Decimal digits to keep.\n");

            Console.WriteLine("Type \"b\" to go back to the main menu.\n");

            var input = Console.ReadLine().ToLower();

            while (input != "b" || input != "back" || input != "q" || input != "quit")
            {
                switch (input)
                {
                    case "decimal precision":
                        InputDecimalPrecision();
                        break;
                    case "b":
                    case "back":
                    case "q":
                    case "quit":
                        return;
                }

                Console.Title = "Settings - SharpCalc";

                input = Console.ReadLine().ToLower();
            }
        }

        public static void InputDecimalPrecision()
        {
            Console.Title = "Configuring Decimal Precision... - Quadratic Equation - SharpCalc";

            Console.Write("\nType a non-negative integer number: ");

            try
            {
                int decimalsToKeep = int.Parse(Console.ReadLine());

                if (decimalsToKeep >= 0)
                {
                    Configs.UpdateSetting<int>("decimalsToKeep", decimalsToKeep);
                    Console.WriteLine("\nThe decimal precision is now {0} digits long. Restart the program to apply changes.\n",
                                      decimalsToKeep);
                }
                else
                {
                    Console.WriteLine("\nYou entered an invalid, negative number. The configuration was cancelled.\n");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nYou did not enter a valid integer number. The configuration was cancelled.\n");
            }
        }
    }
}