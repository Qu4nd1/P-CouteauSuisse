using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouteauSuisse.Display;

namespace CouteauSuisse.Features
{
    static class ConversionBase
    {

        static public bool running = true;
        static public string? answerUser = "";
        static public string? answerConverted = "";

        public static void BaseMain()
        {
            do
            {
                int choice = ConversionBaseMenu.RunInteractive();

                if (ConversionBaseMenu.options[choice - 1] == "Back To Menu")
                {
                    running = false;
                }
                else
                {
                    ConversionBaseMenu.HandleChoice(choice);
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
    }
}
