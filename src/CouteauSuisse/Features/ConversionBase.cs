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
        static public string answerUser;
        static public string answerConverted;

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
            Console.Write("Entrez une valeur entière et postive: ");
            answerUser = Console.ReadLine();

            return answerUser;
        }
        public static void Transformation(int optionNumber)
        {
            double answerToConvert = Convert.ToDouble(answerUser);
            double answerConverting = 0;
            int baseNumber = 0;
            int power = 0;

            if (optionNumber == 1)
            {
                baseNumber = 2;
                while (answerToConvert >= Math.Pow(baseNumber, power))
                {
                    power++;
                }
                for (int i = power; i > -1; i--)
                {
                    if (Math.Pow(baseNumber, i) <= answerToConvert)
                    {
                        answerToConvert -= Math.Pow(baseNumber, i);
                        answerConverted += "1";
                    }
                    else
                        answerConverted += "0";
                }
            }
            else if (optionNumber == 2)
            {
                baseNumber = 2;
                power = answerUser.Length;
                for (int i = 0; i < answerUser.Length; i++)
                {
                    power--;
                    if (answerUser[i] == '1')
                        answerConverting = answerConverting + Math.Pow(baseNumber, power);
                }
                answerConverted = answerConverting.ToString();
            }
            Console.WriteLine($"Le résultat est: {answerConverted}");
            answerConverted = "";
        }
    }
}
