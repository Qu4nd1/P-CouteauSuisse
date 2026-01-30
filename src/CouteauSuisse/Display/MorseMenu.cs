using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouteauSuisse.Features;

namespace CouteauSuisse.Display
{
    static class MorseMenu
    {
        static public string[] options = new string[] { "Morse Visuel", "Morse Audio", "Back To Menu" };
        static public int selectedIndex = 0;
        public static void ShowTitle()
        {
            Console.WriteLine(@" __  __  ___   ____  ____  _____ 
|  \/  |/ _ \ |  _ \/ ___|| ____|
| |\/| | | | || |_) \___ \|  _|  
| |  | | |_| ||  _ < ___) | |___ 
|_|  |_|\___/ |_| \_\____/|_____|");
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

        public static void HandleChoice(int morseMenuChoice)
        {
            if (morseMenuChoice == -1 || morseMenuChoice < 1 || morseMenuChoice > options.Length)
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            string morseMenuSelectedOption = options[morseMenuChoice - 1];

            Console.Clear();
            Console.WriteLine("");

            switch (morseMenuSelectedOption)
            {
                case "Morse Visuel":
                    Console.WriteLine("\t\t=== Morse ===");
                    Console.WriteLine("");
                    Morse.answerUser = Morse.AskUser();
                    Morse.answerConverted = Morse.ConvertToMorse(Morse.answerUser, Morse.answerConverted);
                    Console.WriteLine($"\tRéponse: '{Morse.answerConverted}'");
                    break;
                case "Morse Audio":
                    Console.WriteLine("\t\t=== Morse Audio ===");
                    Console.WriteLine("");
                    Morse.answerUser = Morse.AskUser();
                    Morse.answerConverted = Morse.ConvertToMorse(Morse.answerUser, Morse.answerConverted);
                    Morse.ConvertMorseToSound(Morse.answerConverted);
                    break;
                case "Back To Menu":

                    break;
            }
        }
    }
}
