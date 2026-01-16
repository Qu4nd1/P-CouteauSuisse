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
                    menuOptions = new string[] { "Morse", "Quit" };
                    menuSelectedIndex = 0;
                }

                void Menu_ShowTitle()
                {
                    Console.WriteLine(@"                                                 
                                     @@@@@@@@@@@@@@@@                                     
                                 @@@@@@@@@@@@@@@@@@@@@@@@                                 
                              @@@@@@         +        @@@@@@.                             
                           @@@@@@                        @@@@@@                           
                            @@@                            @@@                            
                            @@@                            @@@                            
                             @@@          @@@@@@          @@@                             
                             @@@          @@@@@@          @@@                             
                             @@@          @@@@@@          @@@                             
                             @@@    @@@@@@@@@@@@@@@@@@    @@@                             
                             @@@@  @@@@@@@@@@@@@@@@@@@@  @@@@                             
                             @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                             
                             @@@    @@@@@@@@@@@@@@@@@@    @@@                             
                             @@@          @@@@@@          @@@                             
                             @@@          @@@@@@          @@@                             
                             @@@          @@@@@@          @@@                             
                            @@@                            @@@                            
                            @@@                            @@@                            
                           @@@@@@                        @@@@@@                           
                              @@@@@@@                @@@@@@@                              
                                  @@@@@@          @@@@@@                                  
                                     @@@@@      @@@@@                                     
                                        @@@@  @@@@:                                       
                                          @@@@@@                                          
                                            @@                                            
                                                                                          
                                                                                          
                                                                                          
              :@   @  @#  @@ @ @@@@@  @@@@   @@@@   @   @-  @   @@@@  @@  @               
               @@ @   @  @@      @   @@   @  @   @  @   @@@ @  @*   @   @@                
                @@@   @  @@      @   @@   @  @@@@   @      @@  @@   @  @@@                
                 @    @@   @@@   @@    @@@   @@  @ @@@  @@  @   *@@@  @@  @@                                                                            
                    ");
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
                    Console.WriteLine($">>> {menuSelectedOption.ToUpper()} <<<");
                    Console.WriteLine("");

                    switch (menuSelectedOption)
                    {
                        case "Morse":
                            Console.WriteLine("=== OPTIONS ===");
                            MainMorse();
                            break;
                        case "Quit":
                            Console.WriteLine("Thanks for playing!");
                            Console.WriteLine("Goodbye!");
                            break;
                    }
                }

            }
            static void MainMorse()
            {
                string? answerUser = "";
                string answerConverted = "";

                MorseMenu();
                answerUser = AskUser();
                ConvertToMorse(answerUser,answerConverted);

                void MorseMenu()
                {
                    Console.Clear();
                    Console.WriteLine("\t=== Convertisseur de texte en code Morse ===");
                    
                }
                string AskUser()
                {
                    Console.WriteLine("Entrez une mot ou une phrase (sans accents, lettres A-Z) :");
                    answerUser = Console.ReadLine();

                    return answerUser;
                }

                void ConvertToMorse(string answerUser, string answerConverted)
                {
                    char letterCheck = ' ';
                    string letterConverted = " ";
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

                    for (int i = 0; i < answerUser.Length; i++)
                    {
                        letterNotFound = true;
                        letterCheck = answerUser[i];
                        letterCheck = char.ToUpper(letterCheck);

                        for (int j = 0; j < morseTable.Count && letterNotFound; j++)
                            if (morseTable.TryGetValue(letterCheck, out letterConverted))
                            {
                                answerConverted = answerConverted + letterConverted;
                                letterNotFound = false;
                            }
                        answerConverted = answerConverted + " ";
                    }
                    Console.WriteLine($"Voici la réponse après convertion : \n '{answerConverted}'");
                    
                }
            }
        }
    }
}
