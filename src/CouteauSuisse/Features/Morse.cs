using CouteauSuisse.Display;

namespace CouteauSuisse.Features
{
    class Morse
    {
        private bool _running = true;
        public string AnswerUser = "";
        public string AnswerConverted = "";
        private bool _letterFound = false;
        private string? _letterConverted = " ";

        public void MorseMain(Morse morse, Verifications verifications)
        {
            MorseMenu morseMenu = new MorseMenu();
            do
            {
                int choice = morseMenu.RunInteractive();

                if (morseMenu.Options[choice - 1] == "Back To Menu")
                {
                    _running = false;
                }
                else
                {
                    morseMenu.HandleChoice(choice, morse, verifications);
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey(true);
                }
            } while (_running);
        }
        public string AskUser()
        {
            Console.Write("Entrez une mot ou une phrase (sans accents, lettres A-Z) :");
            AnswerUser = Console.ReadLine();

            return AnswerUser;
        }
        public string ConvertToMorse(string answerUser)
        {
            char letterCheck = ' ';
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
            AnswerConverted = "";
            for (int i = 0; i < answerUser.Length; i++)
            {
                _letterFound = false;
                letterCheck = answerUser[i];
                letterCheck = char.ToUpper(letterCheck);
                // Repeats until letterFound is set to true or until the end of the dictionnary (character not found)
                for (int j = 0; j < morseTable.Count && !_letterFound; j++)
                    if (morseTable.TryGetValue(letterCheck, out _letterConverted))
                    {
                        AnswerConverted += _letterConverted;
                        _letterFound = true;
                    }
                AnswerConverted += " ";
            }
            return AnswerConverted;
        }

        public string MorseToText(string message)
        {
            string decodedMessage = "";
            string morseLetter = "";
            bool letterCompleted = false;
            char morseLetterConverted;
            Dictionary<string, char> reversedMorseTable = new Dictionary<string, char>
            {
                // Letters
                {".-",'A'},    {"-...", 'B'},  {"-.-.", 'C'}, {"-..", 'D'},
                {".", 'E'},     {"..-.", 'F'},  {"--.", 'G'},  {"....", 'H'},
                {"..", 'I'},    {".---", 'J'},  {"-.-", 'K'},  {".-..", 'L'},
                {"--", 'M'},    {"-.", 'N'},    {"---", 'O'},  {".--.", 'P'},
                {"--.-", 'Q'},  {".-.",'R'},   {"...", 'S'},  {"-", 'T'},
                {"..-", 'U'},   {"...-", 'V'},  {".--", 'W'},  {"-..-", 'X'},
                {"-.--", 'Y'},  {"--..", 'Z'},
                // For spaces between words
                {"/", ' '}
            };
            
            AnswerConverted = ""; // Reset de la variable
            for (int i = 0; i < message.Length; i++)
            {
                // si la lettre n'est pas finie
                if (!letterCompleted)
                {
                    switch (message[i])
                    {
                        // Point
                        case '\u200B':
                            morseLetter += '.';
                            break;
                        // Trait
                        case '\u200C':
                            morseLetter += '-';
                            break;
                    }
                }
                // Si la lettre est finie
                else if (letterCompleted)
                {
                    for (int j = 0; j < reversedMorseTable.Count && !_letterFound; j++)
                        if (reversedMorseTable.TryGetValue(morseLetter, out morseLetterConverted))
                        {
                            AnswerConverted += morseLetterConverted;
                            _letterFound = true;
                        }
                    _letterFound = false; // Reset de la variable
                }
                // Esapce entre lettres
                else if (message[i] == '\u200D')
                {
                    morseLetter = ""; // Reset de la variable
                }
                // Esapace entre mots
                else if (message[i] == '\u2060')
                {
                    AnswerConverted += ' ';
                }
            }
            return decodedMessage;
        }
        public void ConvertMorseToSound(string crtAnswerConverted)
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
    
}



