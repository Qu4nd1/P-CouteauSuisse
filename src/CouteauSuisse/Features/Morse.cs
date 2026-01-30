using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouteauSuisse.Display;

namespace CouteauSuisse.Features
{
    static class Morse
    {
        static public bool running = true;
        static public string? answerUser = "";
        static public string? answerConverted = "";

        public static void MorseMain()
        {
            do
            {
                int choice = MorseMenu.RunInteractive();

                if (MorseMenu.options[choice - 1] == "Back To Menu")
                {
                    running = false;
                }
                else
                {
                    MorseMenu.HandleChoice(choice);
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey(true);
                }
            } while (running);
        }
        public static string AskUser()
        {
            Console.WriteLine("Entrez une mot ou une phrase (sans accents, lettres A-Z) :");
            answerUser = Console.ReadLine();

            return answerUser;
        }
        public static string ConvertToMorse(string answerUser, string answerConverted)
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

            answerConverted = "";
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
            return answerConverted;
        }
        public static void ConvertMorseToSound(string crtAnswerConverted)
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



