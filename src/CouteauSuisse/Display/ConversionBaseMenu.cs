using CouteauSuisse.Features;

namespace CouteauSuisse.Display
{
    class ConversionBaseMenu
    {
        private string[] _options = new string[] { "Décimal --> Binaire", "Binaire --> Décimal", "Binaire --> Octal", "Octal --> Binaire", "Back To Menu" };
        public string[] Options { get { return _options; } }
        private int _selectedIndex = 0;
        private void ShowTitle()
        {
            Console.WriteLine(@" ____    _    ____  _____ 
| __ )  / \  / ___|| ____|
|  _ \ / _ \ \___ \|  _|  
| |_) / ___ \ ___) | |___ 
|____/_/   \_\____/|_____|");
        }
        private void ShowInteractive()
        {
            Console.Clear();
            ShowTitle();
            Console.WriteLine("");
            Console.WriteLine("Use ↑↓ arrows to navigate, Enter to select");
            Console.WriteLine("");

            for (int i = 0; i < _options.Length; i++)
            {
                if (i == _selectedIndex)
                {
                    // Highlight selected option
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine($"  > {_options[i]} <  ");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"    {_options[i]}    ");
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
                        _selectedIndex = _options.Length - 1; // Wrap to bottom
                    }
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    // If Last Option go to First Option
                    if (_selectedIndex >= _options.Length)
                    {
                        _selectedIndex = 0; // Wrap to top
                    }
                }

            } while (key != ConsoleKey.Enter);

            return _selectedIndex + 1; // Return 1-based choice
        }

        public void HandleChoice(int choice,ConversionBase conversionBase, Verifications verifications)
        {
            if (choice == -1 || choice < 1 || choice > _options.Length)
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            string selectedOption = _options[choice - 1];

            Console.Clear();
            Console.WriteLine("");

            switch (selectedOption)
            {
                case "Décimal --> Binaire":
                    Console.WriteLine("\t\t=== Décimal --> Binaire ===");
                    Console.WriteLine("");
                    verifications.IntAndRangeCheck(1, conversionBase.AskUser(), conversionBase);
                    conversionBase.Transformation(1);
                    break;
                case "Binaire --> Décimal":
                    Console.WriteLine("\t\t=== Binaire --> Décimal ===");
                    Console.WriteLine("");
                    verifications.IntAndRangeCheck(2, conversionBase.AskUser(), conversionBase);
                    conversionBase.Transformation(2);
                    break;
                case "Binaire --> Octal":
                    Console.WriteLine("\t\t=== Binaire --> Octal ===");
                    Console.WriteLine("");
                    verifications.IntAndRangeCheck(3, conversionBase.AskUser(), conversionBase);
                    conversionBase.Transformation(3);
                    break;
                case "Octal --> Binaire":
                    Console.WriteLine("\t\t=== Octal --> Binaire ===");
                    Console.WriteLine("");
                    verifications.IntAndRangeCheck(4, conversionBase.AskUser(), conversionBase);
                    conversionBase.Transformation(4);
                    break;
                case "Back To Menu":

                    break;
            }
        }
    }
}
