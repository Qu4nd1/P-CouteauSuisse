using CouteauSuisse.Features;
namespace CouteauSuisse.Display;

class SteganographieMenu
{
        public string[] Options = new string[] { "Encoder", "Décoder", "Back To Menu" };
        private int _selectedIndex = 0;
        public void ShowTitle()
        {
            Console.WriteLine(@"
  ____   _____   _____    ___     _      _   _    ___    ___    ____       _     ___    _   _   _____   _____
 / ___| |_   _| | ____|  / __|   / \    | \ | |  / _ \  / __|  |  _ \     / \   |  _ \ | |_| | |_   _| | ____|
 \___ \   | |   |  _|   | |  _  / _ \   |  \| | | | | || |  _  | |_) |   / _ \  | |_) ||     |   | |   |  _|
  ___) |  | |   | |___  | |_| |/ ___ \  | |\  | | |_| || |_| | |  _ <   / ___ \ |  __/ |  _  |  _| |_  | |___
 |____/   |_|   |_____|  \___//_/   \_\ |_| \_|  \___/  \___/  |_| \_\ /_/   \_\|_|    |_| |_| |_____| |_____|");
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
                    // If Firt Option go to Last Option
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

        public void HandleChoice(int morseMenuChoice, Steganographie steganographie, Morse morse, Verifications verifications)
        {
            if (morseMenuChoice == -1 || morseMenuChoice < 1 || morseMenuChoice > Options.Length)
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            string morseMenuSelectedOption = Options[morseMenuChoice - 1];

            Console.Clear();
            Console.WriteLine("");

            switch (morseMenuSelectedOption)
            {
                case "Encoder":
                    Console.WriteLine("\t\t=== Encodage ===");
                    Console.WriteLine("");
                    steganographie.AskUser(true);
                    steganographie.EncodingTransformation(morse);
                    break;
                case "Décoder":
                    Console.WriteLine("\t\t=== Décodage ===");
                    Console.WriteLine("");
                    steganographie.DecodingTransformation(morse);
                    
                    break;
                case "Back To Menu":

                    break;
            }
        }   
}