using CouteauSuisse.Features;

namespace CouteauSuisse.Display
{
    class Menu
    {
        // Global variables
        public string[] Options = Array.Empty<string>();
        private int _selectedIndex = 0;
        public void Init()
        {
            Options = new string[] { "Morse", "Conversion de Base","Stéganographie" , "Quit" };
            _selectedIndex = 0;
        }
        private void ShowTitle()
        {
            Console.WriteLine(@"
 ____  __        __ ___   ____    ____  
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
        private void ShowInteractive()
        {
            Console.Clear();
            ShowTitle();
            Console.WriteLine("");
            Console.WriteLine("Use ↑↓ arrows to navigate, Enter to select");
            Console.WriteLine("");

            for (int i = 0; i < Options.Length; i++)
            {
                if (i == _selectedIndex)
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
        public int RunInteractive()
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
                    // If First Option go to Last Option
                    _selectedIndex--;
                    if (_selectedIndex < 0)
                    {
                        _selectedIndex = Options.Length - 1; // Wrap to bottom
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    // If Last Option go to First Option
                    if (_selectedIndex >= Options.Length)
                    {
                        _selectedIndex = 0; // Wrap to top
                    }
                }

            } while (key != ConsoleKey.Enter);

            return _selectedIndex + 1; // Return 1-based choice
        }
        public void HandleChoice(int menuChoice, Morse morse, ConversionBase conversionBase, Steganographie steganographie, Verifications verifications)
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
                    morse.MorseMain(morse, verifications);
                    break;
                case "Conversion de Base":
                    conversionBase.BaseMain(conversionBase, verifications);
                    break;
                case "Stéganographie":
                    steganographie.StegMain(steganographie, morse, verifications);
                    break;
                case "Quit":
                    Console.WriteLine("Thanks for playing!");
                    Console.WriteLine("Goodbye!");
                    break;
            }
        }

    }
}
