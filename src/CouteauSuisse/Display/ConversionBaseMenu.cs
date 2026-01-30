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
        static public string[] options = new string[] { "Binaire", "Octal", "Decimal", "Hexadecimal", "Back To Menu" };
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

        public static void HandleChoice(int baseMenuChoice)
        {
            if (baseMenuChoice == -1 || baseMenuChoice < 1 || baseMenuChoice > options.Length)
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            string morseMenuSelectedOption = options[baseMenuChoice - 1];

            Console.Clear();
            Console.WriteLine("");

            switch (morseMenuSelectedOption)
            {
                case "Binaire":
                    Console.WriteLine("\t\t=== Binaire ===");
                    Console.WriteLine("");
                    ConversionBase.AskUser();

                    break;
                case "Octal":
                    Console.WriteLine("\t\t=== Octal ===");
                    Console.WriteLine("");
                    ConversionBase.AskUser();

                    break;
                case "Decimal":
                    Console.WriteLine("\t\t=== Decimal ===");
                    Console.WriteLine("");
                    ConversionBase.AskUser();

                    break;
                case "Hexadecimal":
                    Console.WriteLine("\t\t=== Hexadecimal ===");
                    Console.WriteLine("");
                    ConversionBase.AskUser();

                    break;
                case "Back To Menu":

                    break;
            }
        }
    }
}
