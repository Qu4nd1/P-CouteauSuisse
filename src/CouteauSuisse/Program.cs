using Microsoft.VisualBasic;

namespace CouteauSuisse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Global variables
            string[] menuOptions = Array.Empty<string>();
            int menuSelectedIndex = 0;

            // Main program
            bool running = true;

            while (running)
            {
                Menu_Init();
                int menuChoice = Menu_RunInteractive();



                if (menuOptions[menuChoice - 1] == "Quit")
                {
                    running = false;
                }
                else
                {
                    Menu_HandleChoice(menuChoice);
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey(true);
                }


                void Menu_Init()
                {
                    menuOptions = new string[] { "Morse", "Conversion de Base", "Quit" };
                    menuSelectedIndex = 0;
                }

                void Menu_ShowTitle()
                {
                    Console.WriteLine(@" ____  __        __ ___   ____    ____  
/ ___| \ \      / /|_ _| / ___>  / ___| 
\___ \  \ \ /\ / /  | |  \___ \  \___ \ 
 ___) |  \ V  V /   | |   ___) |  ___) |
|____/    \_/\_/   |___| |____/  |____/ 
                                     
 _  __ _   _  ___  _____ _____ 
| |/ /| \ | ||_ _||  ___| ____|
|   / |  \| | | | | |_  |  _|  
| \ \ | |\  | | | |  _| | |___ 
|_|\_\|_| \_||___||_|   |_____|");
                }

                void Menu_ShowInteractive()
                {
                    Console.Clear();
                    Menu_ShowTitle();
                    Console.WriteLine("");
                    Console.WriteLine("Use ↑↓ arrows to navigate, Enter to select");
                    Console.WriteLine("");

                    for (int i = 0; i < menuOptions.Length; i++)
                    {
                        if (i == menuSelectedIndex)
                        {
                            // Highlight selected option
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine($"  > {menuOptions[i]} <  ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"    {menuOptions[i]}    ");
                        }
                    }

                    Console.WriteLine("");
                }

                int Menu_RunInteractive()
                {
                    ConsoleKey key;

                    do
                    {
                        Menu_ShowInteractive();

                        // Read key without displaying it
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        key = keyInfo.Key;

                        // Handle navigation
                        if (key == ConsoleKey.UpArrow)
                        {
                            // If Firt Option go to Last Option
                            menuSelectedIndex--;
                            if (menuSelectedIndex < 0)
                            {
                                menuSelectedIndex = menuOptions.Length - 1; // Wrap to bottom
                            }
                        }
                        else if (key == ConsoleKey.DownArrow)
                        {
                            menuSelectedIndex++;
                            // If Last Option go to First Option
                            if (menuSelectedIndex >= menuOptions.Length)
                            {
                                menuSelectedIndex = 0; // Wrap to top
                            }
                        }

                    } while (key != ConsoleKey.Enter);

                    return menuSelectedIndex + 1; // Return 1-based choice
                }

                void Menu_HandleChoice(int menuChoice)
                {
                    if (menuChoice == -1 || menuChoice < 1 || menuChoice > menuOptions.Length)
                    {
                        Console.WriteLine("Invalid choice!");
                        return;
                    }

                    string menuSelectedOption = menuOptions[menuChoice - 1];

                    Console.Clear();
                    Console.WriteLine("");

                    switch (menuSelectedOption)
                    {
                        case "Morse":
                            Console.WriteLine("\t\t=== Morse ===");
                            Console.WriteLine("");
                            MainMorse();
                            break;
                        case "Conversion de Base":
                            Console.WriteLine("\t\t=== Conversion de Base ===");
                            Console.WriteLine("");
                            ConversionBase();

                            break;
                        case "Quit":
                            Console.WriteLine("Thanks for playing!");
                            Console.WriteLine("Goodbye!");
                            break;
                    }
                }
            }

        }

        static void MainMorse()
        {
            string[] morseMenuOptions = new string[] { "Morse Visuel", "Morse Audio", "Back To Menu" };
            int morseMenuSelectedIndex = 0;
            bool morseRunning = true;
            string? morseAnswerUser = "";
            string? morseAnswerConverted = "";

            do
            {
                int morseMenuChoice = MorseMenu_RunInteractive();

                if (morseMenuOptions[morseMenuChoice - 1] == "Back To Menu")
                {
                    morseRunning = false;
                }
                else
                {
                    MorseMenu_HandleChoice(morseMenuChoice);
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey(true);
                }
            } while (morseRunning);

            void MorseMenu_ShowTitle()
            {
            Console.WriteLine(@" __  __  ___   ____  ____  _____ 
|  \/  |/ _ \ |  _ \/ ___|| ____|
| |\/| | | | || |_) \___ \|  _|  
| |  | | |_| ||  _ < ___) | |___ 
|_|  |_|\___/ |_| \_\____/|_____|");
            }
            void MorseMenu_ShowInteractive()
            {
                Console.Clear();
                MorseMenu_ShowTitle();
                Console.WriteLine("");
                Console.WriteLine("Use ↑↓ arrows to navigate, Enter to select");
                Console.WriteLine("");

                for (int i = 0; i < morseMenuOptions.Length; i++)
                {
                    if (i == morseMenuSelectedIndex)
                    {
                        // Highlight selected option
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"  > {morseMenuOptions[i]} <  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"    {morseMenuOptions[i]}    ");
                    }
                }

                Console.WriteLine("");
            }

            int MorseMenu_RunInteractive()
            {
                ConsoleKey key;

                do
                {
                    MorseMenu_ShowInteractive();

                    // Read key without displaying it
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    key = keyInfo.Key;

                    // Handle navigation
                    if (key == ConsoleKey.UpArrow)
                    {
                        // If Firt Option go to Last Option
                        morseMenuSelectedIndex--;
                        if (morseMenuSelectedIndex < 0)
                        {
                            morseMenuSelectedIndex = morseMenuOptions.Length - 1; // Wrap to bottom
                        }
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        morseMenuSelectedIndex++;
                        // If Last Option go to First Option
                        if (morseMenuSelectedIndex >= morseMenuOptions.Length)
                        {
                            morseMenuSelectedIndex = 0; // Wrap to top
                        }
                    }

                } while (key != ConsoleKey.Enter);

                return morseMenuSelectedIndex + 1; // Return 1-based choice
            }

            void MorseMenu_HandleChoice(int morseMenuChoice)
            {
                if (morseMenuChoice == -1 || morseMenuChoice < 1 || morseMenuChoice > morseMenuOptions.Length)
                {
                    Console.WriteLine("Invalid choice!");
                    return;
                }

                string morseMenuSelectedOption = morseMenuOptions[morseMenuChoice - 1];

                Console.Clear();
                Console.WriteLine("");

                switch (morseMenuSelectedOption)
                {
                    case "Morse Visuel":
                        Console.WriteLine("\t\t=== Morse ===");
                        Console.WriteLine("");
                        morseAnswerUser = MorseAskUser();
                        morseAnswerConverted = ConvertToMorse(morseAnswerUser, morseAnswerConverted);
                        Console.WriteLine($"\tRéponse: '{morseAnswerConverted}'");
                        break;
                    case "Morse Audio":
                        Console.WriteLine("\t\t=== Morse Audio ===");
                        Console.WriteLine("");
                        morseAnswerUser = MorseAskUser();
                        morseAnswerConverted = ConvertToMorse(morseAnswerUser, morseAnswerConverted);
                        ConvertMorseToSound(morseAnswerConverted);
                        break;
                    case "Back To Menu":

                        break;
                }
            }
            string MorseAskUser()
            {
                Console.WriteLine("Entrez une mot ou une phrase (sans accents, lettres A-Z) :");
                morseAnswerUser = Console.ReadLine();

                return morseAnswerUser;
            }
            string ConvertToMorse(string answerUser, string answerConverted)
            {
                char letterCheck = ' ';
                string? letterConverted = " ";
                bool letterNotFound = true;

                Dictionary<char, string> morseTable = new Dictionary<char, string>
                    {
                        // Letters
                        {'A', ".-"},    {'B', "-..."},  {'C', "-.-."}, {'D', "-.."},
                        {'E', "."},     {'F', "..-."},  {'G', "--."},  {'H', "...."},
                        {'I', ".."},    {'J', ".---"},  {'K', "-.-"},  {'L', ".-.."},
                        {'M', "--"},    {'N', "-."},    {'O', "---"},  {'P', ".--."},
                        {'Q', "--.-"},  {'R', ".-."},   {'S', "..."},  {'T', "-"},
                        {'U', "..-"},   {'V', "...-"},  {'W', ".--"},  {'X', "-..-"},
                        {'Y', "-.--"},  {'Z', "--.."},
                        // For spaces between words
                        {' ', "/"}
                    };

                morseAnswerConverted = "";
                for (int i = 0; i < morseAnswerUser.Length; i++)
                {
                    letterNotFound = true;
                    letterCheck = morseAnswerUser[i];
                    letterCheck = char.ToUpper(letterCheck);

                    for (int j = 0; j < morseTable.Count && letterNotFound; j++)
                        if (morseTable.TryGetValue(letterCheck, out letterConverted))
                        {
                            morseAnswerConverted = morseAnswerConverted + letterConverted;
                            letterNotFound = false;
                        }
                    morseAnswerConverted = morseAnswerConverted + " ";
                }
                return morseAnswerConverted;
            }

            void ConvertMorseToSound(string crtAnswerConverted)
            {
                int unit = 200;
                for (int i = 0; i < crtAnswerConverted.Length; i++)
                {
                    // POINT
                    if (crtAnswerConverted[i] == '.')
                    {
                        Console.Write(crtAnswerConverted[i]);
                        Console.Beep(800, unit);
                        Thread.Sleep(unit);        // silence après le point
                    }
                    // TRAIT
                    else if (crtAnswerConverted[i] == '-')
                    {
                        Console.Write(crtAnswerConverted[i]);
                        Console.Beep(800, unit * 3);
                        Thread.Sleep(unit);            // silence après le trait
                    }
                    // ESPACE ENTRE LETTRE
                    else if (crtAnswerConverted[i] == ' ')
                    {
                        Console.Write(crtAnswerConverted[i]);
                        Thread.Sleep(unit * 2);  // 2 unités supplémentaires (car on a déjà 1 unité après chaque symbole)
                    }
                    // ESPACE ENTRE MOT
                    else if (crtAnswerConverted[i] == '/')
                    {
                        Console.Write(crtAnswerConverted[i]);
                        Thread.Sleep(unit * 6);  // 6 unités supplémentaires (1 déjà présente + 6 = 7 total)
                    }
                }
            }
            
        }
        static void ConversionBase()
        {
            string[] baseMenuOptions = new string[] { "Binaire", "Octal", "Decimal", "Hexadecimal", "Back To Menu" };
            int baseMenuSelectedIndex = 0;
            bool baseRunning = true;
            string? baseAnswerUser = "";
            string? baseAnswerConverted = "";

            do
            {
                int baseMenuChoice = BaseMenu_RunInteractive();

                if (baseMenuOptions[baseMenuChoice - 1] == "Back To Menu")
                {
                    baseRunning = false;
                }
                else
                {
                    BaseMenu_HandleChoice(baseMenuChoice);
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey(true);
                }
            } while (baseRunning);

            void BaseMenu_ShowTitle()
            {
                Console.WriteLine(@" ____    _    ____  _____ 
| __ )  / \  / ___|| ____|
|  _ \ / _ \ \___ \|  _|  
| |_) / ___ \ ___) | |___ 
|____/_/   \_\____/|_____|");
            }
            void BaseMenu_ShowInteractive()
            {
                Console.Clear();
                BaseMenu_ShowTitle();
                Console.WriteLine("");
                Console.WriteLine("Use ↑↓ arrows to navigate, Enter to select");
                Console.WriteLine("");

                for (int i = 0; i < baseMenuOptions.Length; i++)
                {
                    if (i == baseMenuSelectedIndex)
                    {
                        // Highlight selected option
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"  > {baseMenuOptions[i]} <  ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"    {baseMenuOptions[i]}    ");
                    }
                }

                Console.WriteLine("");
            }

            int BaseMenu_RunInteractive()
            {
                ConsoleKey key;

                do
                {
                    BaseMenu_ShowInteractive();

                    // Read key without displaying it
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    key = keyInfo.Key;

                    // Handle navigation
                    if (key == ConsoleKey.UpArrow)
                    {
                        // If Firt Option go to Last Option
                        baseMenuSelectedIndex--;
                        if (baseMenuSelectedIndex < 0)
                        {
                            baseMenuSelectedIndex = baseMenuOptions.Length - 1; // Wrap to bottom
                        }
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        baseMenuSelectedIndex++;
                        // If Last Option go to First Option
                        if (baseMenuSelectedIndex >= baseMenuOptions.Length)
                        {
                            baseMenuSelectedIndex = 0; // Wrap to top
                        }
                    }

                } while (key != ConsoleKey.Enter);

                return baseMenuSelectedIndex + 1; // Return 1-based choice
            }

            void BaseMenu_HandleChoice(int baseMenuChoice)
            {
                if (baseMenuChoice == -1 || baseMenuChoice < 1 || baseMenuChoice > baseMenuOptions.Length)
                {
                    Console.WriteLine("Invalid choice!");
                    return;
                }

                string morseMenuSelectedOption = baseMenuOptions[baseMenuChoice - 1];

                Console.Clear();
                Console.WriteLine("");

                switch (morseMenuSelectedOption)
                {
                    case "Binaire":
                        Console.WriteLine("\t\t=== Binaire ===");
                        Console.WriteLine("");
                       
                        break;
                    case "Octal":
                        Console.WriteLine("\t\t=== Octal ===");
                        Console.WriteLine("");
                        
                        break;
                    case "Decimal":
                        Console.WriteLine("\t\t=== Decimal ===");
                        Console.WriteLine("");

                        break;
                    case "Hexadecimal":
                        Console.WriteLine("\t\t=== Hexadecimal ===");
                        Console.WriteLine("");

                        break;
                    case "Back To Menu":

                        break;
                }
            }
            string BaseAskUser()
            {
                Console.WriteLine("Entrez une mot ou une phrase (sans accents, lettres A-Z) :");
                baseAnswerUser = Console.ReadLine();

                return baseAnswerUser;
            }
            
        }
    }
}
