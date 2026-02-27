using CouteauSuisse.Features;

namespace CouteauSuisse.Display
{
    class MorseMenu
    {
        public string[] Options = new string[] { "Morse Visuel", "Morse Audio", "Back To Menu" };
        private int _selectedIndex = 0;
        public void ShowTitle()
        {
            Console.WriteLine(@" __  __  ___   ____  ____  _____ 
|  \/  |/ _ \ |  _ \/ ___|| ____|
| |\/| | | | || |_) \___ \|  _|  
| |  | | |_| ||  _ < ___) | |___ 
|_|  |_|\___/ |_| \_\____/|_____|");
        }
        public void ShowInteractive()
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

        public void HandleChoice(int morseMenuChoice, Morse morse, Verifications verifications)
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
                case "Morse Visuel":
                    Console.WriteLine("\t\t=== Morse ===");
                    Console.WriteLine("");
                    morse.AnswerUser = morse.AskUser();
                    morse.AnswerConverted = morse.ConvertToMorse(morse.AnswerUser);
                    Console.WriteLine($"\tRéponse: '{morse.AnswerConverted}'");
                    break;
                case "Morse Audio":
                    Console.WriteLine("\t\t=== Morse Audio ===");
                    Console.WriteLine("");
                    morse.AnswerUser = morse.AskUser();
                    morse.AnswerConverted = morse.ConvertToMorse(morse.AnswerUser);
                    morse.ConvertMorseToSound(morse.AnswerConverted);
                    break;
                case "Back To Menu":

                    break;
            }
        }
    }
}
