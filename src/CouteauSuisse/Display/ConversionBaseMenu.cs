using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouteauSuisse.Features;

namespace CouteauSuisse.Display
{
    static class ConversionBaseMenu
    {
        static public string[] options = new string[] { "Décimal --> Binaire", "Binaire --> Décimal", "Binaire --> Octal", "Octal --> Binaire", "Back To Menu" };
        static public int selectedIndex = 0;
        public static void ShowTitle()
        {
            Console.WriteLine(@" ____    _    ____  _____ 
| __ )  / \  / ___|| ____|
|  _ \ / _ \ \___ \|  _|  
| |_) / ___ \ ___) | |___ 
|____/_/   \_\____/|_____|");
        }
        public static void ShowInteractive()
        {
            Console.Clear();
            ShowTitle();
            Console.WriteLine("");
            Console.WriteLine("Use ↑↓ arrows to navigate, Enter to select");
            Console.WriteLine("");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    // Highlight selected option
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"  > {options[i]} <  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"    {options[i]}    ");
                }
            }

            Console.WriteLine("");
        }

        public static int RunInteractive()
        {
            ConsoleKey key;

            do
            {
                ShowInteractive();

                // Read key without displaying it
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;

                // Handle navigation
                if (key == ConsoleKey.UpArrow)
                {
                    // If Firt Option go to Last Option
                    selectedIndex--;
                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1; // Wrap to bottom
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    // If Last Option go to First Option
                    if (selectedIndex >= options.Length)
                    {
                        selectedIndex = 0; // Wrap to top
                    }
                }

            } while (key != ConsoleKey.Enter);

            return selectedIndex + 1; // Return 1-based choice
        }

        public static void HandleChoice(int choice)
        {
            if (choice == -1 || choice < 1 || choice > options.Length)
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            string selectedOption = options[choice - 1];

            Console.Clear();
            Console.WriteLine("");

            switch (selectedOption)
            {
                case "Décimal --> Binaire":
                    Console.WriteLine("\t\t=== Décimal --> Binaire ===");
                    Console.WriteLine("");
                    ConversionBase.AskUser();
                    ConversionBase.Transformation(1);
                    break;
                case "Binaire --> Décimal":
                    Console.WriteLine("\t\t=== Binaire --> Décimal ===");
                    Console.WriteLine("");
                    ConversionBase.AskUser();
                    ConversionBase.Transformation(2);
                    break;
                case "Binaire --> Octal":
                    Console.WriteLine("\t\t=== Binaire --> Octal ===");
                    Console.WriteLine("");
                    ConversionBase.AskUser();
                    ConversionBase.Transformation(3);
                    break;
                case "Octal --> Binaire":
                    Console.WriteLine("\t\t=== Octal --> Binaire ===");
                    Console.WriteLine("");
                    ConversionBase.AskUser();
                    ConversionBase.Transformation(4);
                    break;
                case "Back To Menu":

                    break;
            }
        }
    }
}
