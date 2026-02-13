using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouteauSuisse.Features;

namespace CouteauSuisse.Display
{
    static class Menu
    {
        // Global variables
        static public string[] Options = Array.Empty<string>();
        static public int SelectedIndex = 0;
        public static void Init()
        {
            Options = new string[] { "Morse", "Conversion de Base", "Quit" };
            SelectedIndex = 0;
        }
        public static void ShowTitle()
        {
            Console.WriteLine(@" ____  __        __ ___   ____    ____  
/ ___| \ \      / /|_ _| / ___|  / ___| 
\___ \  \ \ /\ / /  | |  \___ \  \___ \ 
 ___) |  \ V  V /   | |   ___) |  ___) |
|____/    \_/\_/   |___| |____/  |____/ 
                                     
 _  __ _   _  ___  _____ _____ 
| |/ /| \ | ||_ _||  ___| ____|
|   / |  \| | | | | |_  |  _|  
| \ \ | |\  | | | |  _| | |___ 
|_|\_\|_| \_||___||_|   |_____|");
        }
        public static void ShowInteractive()
        {
            Console.Clear();
            ShowTitle();
            Console.WriteLine("");
            Console.WriteLine("Use ↑↓ arrows to navigate, Enter to select");
            Console.WriteLine("");

            for (int i = 0; i < Options.Length; i++)
            {
                if (i == SelectedIndex)
                {
                    // Highlight selected option
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"  > {Options[i]} <  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"    {Options[i]}    ");
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
                    SelectedIndex--;
                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = Options.Length - 1; // Wrap to bottom
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    // If Last Option go to First Option
                    if (SelectedIndex >= Options.Length)
                    {
                        SelectedIndex = 0; // Wrap to top
                    }
                }

            } while (key != ConsoleKey.Enter);

            return SelectedIndex + 1; // Return 1-based choice
        }
        public static void HandleChoice(int menuChoice)
        {
            if (menuChoice == -1 || menuChoice < 1 || menuChoice > Options.Length)
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            string menuSelectedOption = Options[menuChoice - 1];

            Console.Clear();
            Console.WriteLine("");

            switch (menuSelectedOption)
            {
                case "Morse":
                    Console.WriteLine("\t\t=== Morse ===");
                    Console.WriteLine("");
                    Morse.MorseMain();
                    break;
                case "Conversion de Base":
                    Console.WriteLine("\t\t=== Conversion de Base ===");
                    Console.WriteLine("");
                    ConversionBase.BaseMain();

                    break;
                case "Quit":
                    Console.WriteLine("Thanks for playing!");
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }

    }
}
