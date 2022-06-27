using System;
using SharpCalc.Utilities;  // Configs.cs

namespace Quadratic
{
    class Settings
    {
        public static void ListSettings()
        {
            Console.Title = "Settings - Quadratic Equation - SharpCalc";

            Console.WriteLine("\nQuadratic Equation Settings:");
            Console.WriteLine("  delta symbol                 Sets the discriminant symbol.");
            Console.WriteLine("  separated delta              Configures the discriminant separation.");
            Console.WriteLine("  step-by-step|resolution      Enables or disables step-by-step reolution.\n");

            Console.WriteLine("Type \"b\" to go back to the main menu.\n");

            var input = Console.ReadLine().ToLower();
            
            while (input != "b" || input != "back" || input != "q" || input != "quit")
            {
                switch (input)
                {
                    case "delta symbol":
                        InputDiscriminantSymbol();
                        break;
                    case "separated delta":
                        InputSeparatedDiscriminant();
                        break;
                    case "step-by-step":  case "resolution":
                        InputStepByStepResolution();
                        break;
                    case "b":  case "back":
                    case "q":  case "quit":
                        return;
                }

                Console.Title = "Settings - Quadratic Equation - SharpCalc";

                input = Console.ReadLine().ToLower();
            }
        }

        public static void InputDiscriminantSymbol()
        {
            Console.Title = "Configuring Discriminant Symbol... - Quadratic Equation - SharpCalc";

            Console.Write("\n\"In the quadratic formula, " +
                "the expression underneath the square root sign is called the discriminant of the quadratic equation" +
                ", and is often represented using an upper case D or an upper case Greek delta.\"\n");
            Console.Write("Type \"D\" (upper case) to use an upper case D as the discriminant symbol" +
                ", or \"d\" (lower case) to use an upper case Greek delta: ");
            
            var discriminantSymbol = Console.ReadLine();
            if (discriminantSymbol == "D")
            {
                Configs.UpdateSetting<string>("sbs:discriminant:symbol", "D", "quadratic");
                Console.WriteLine("\nThe discriminant symbol is now \"D\". Restart the program to apply changes.\n");
            }
            else if (discriminantSymbol == "d")
            {
                Configs.UpdateSetting<string>("sbs:discriminant:symbol", "Δ", "quadratic");
                Console.WriteLine("\nThe discriminant symbol is now \"Δ\". Restart the program to apply changes.\n");
            }
        }

        public static void InputSeparatedDiscriminant()
        {
            Console.Title = "Configuring Discriminant Separation... - Quadratic Equation - SharpCalc";

            Console.Write("\nWould you like to calculate with separated discriminant (delta)? [y/n]: ");

            if (Convert.ToChar(Console.ReadLine()) == 'y')
            {
                Configs.UpdateSetting<bool>("sbs:discriminant:separated", true, "quadratic");
                Console.WriteLine("\nThe step-by-step resolution is now calculated with a separated discriminant. " +
                                  "Restart the program to apply changes.\n");
            }
            else
            {
                Configs.UpdateSetting<bool>("sbs:discriminant:separated", false, "quadratic");
                Console.WriteLine("\nThe step-by-step resolution is now calculated without a separated discriminant. " +
                                  "Restart the program to apply changes.\n");
            }
        }

        public static void InputStepByStepResolution()
        {
            Console.Title = "Configuring Step-By-Step Resolution... - Quadratic Equation - SharpCalc";

            Console.Write("\nShow step-by-step resolution? [y/n]: ");

            if (Convert.ToChar(Console.ReadLine()) == 'y')
            {
                Configs.UpdateSetting<bool>("sbs:enabled", true, "quadratic");
                Console.WriteLine("\nStep-by-step resolution is now enabled. Restart the program to apply changes.\n");
            }
            else
            {
                Configs.UpdateSetting<bool>("sbs:enabled", false, "quadratic");
                Console.WriteLine("\nStep-by-step resolution is now disabled. Restart the program to apply changes.\n");
            }
        }
    }
}