using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public static void IntCheck()
        {
            bool answerValidity = false;
            do
            {
                for (int i = 0; i < answerUser.Length; i++)
                {
                    if (char.IsDigit(answerUser[i]))
                    {
                        answerValidity = true;
                    }
                    else
                        answerValidity = false;
                }
                if (answerValidity != true)
                    AskUser();
            } while (answerValidity != true);
        }
        public static void ValueRangeCheck()
        {

        }
        public static void Transformation(int optionNumber)
        {
            double answerToConvert;
            double answerConverting = 0;
            int baseNumber = 0;
            int power = 0;
            int binary2octalBundleSize = 3;
            int time = 0;
            char[] answerUserTab = new char[answerUser.Length];
            char[] answerTransformtaion = Array.Empty<char>();
            int[] answerIntTransformation = Array.Empty<int>();
            


            for (int i = 0; i < answerUser.Length; i++)
            {
                answerUserTab[i] = answerUser[i];
            }
            if (optionNumber == 1)
            {
                IntCheck();
                answerToConvert = Convert.ToDouble(answerUser);
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
                IntCheck();
                power = answerUser.Length;
                for (int i = 0; i < answerUser.Length; i++)
                {
                    power--;
                    if (answerUser[i] == '1')
                        answerConverting += Math.Pow(baseNumber, power);
                }
                answerConverted = answerConverting.ToString();
            }
            else if (optionNumber == 3)
            {
                baseNumber = 2;
                IntCheck();
                if (answerUser.Length%3 != 0)
                {
                    int originalSize = answerUserTab.Length;
                    int reste = 0;
                    bool found = false;
                    do
                    {
                        if (3 * time > originalSize)
                        {
                            reste = (3 * time) - originalSize;
                            found = true;
                        }
                        time++;
                    } while (found != true);
                    answerTransformtaion = new char[originalSize+reste];
                    Array.Copy(answerUserTab, 0, answerTransformtaion, reste, originalSize); 
                    for (int i = 0; i < reste; i++)
                    {
                        answerTransformtaion[i] = '0';
                    }
                    int count = 0;
                    for (int i = answerTransformtaion.Length / 3; i > 0; i--)
                    {
                        answerConverting = 0;
                        for (int j = binary2octalBundleSize; j > 0; j--)
                        {
                            if (answerTransformtaion[count] == '1')
                                answerConverting += Math.Pow(baseNumber, j-1);
                            count++;
                        }
                        answerConverted += answerConverting.ToString();
                    }
                    
                }
                else
                {
                    answerTransformtaion = new char[answerUserTab.Length];
                    Array.Copy(answerUserTab, answerTransformtaion, answerUserTab.Length);
                    int count = 0;
                    for (int i = answerTransformtaion.Length / 3; i > 0; i--)
                    {
                        answerConverting = 0;
                        for (int j = binary2octalBundleSize; j > 0; j--)
                        {
                            if (answerTransformtaion[count] == '1')
                                answerConverting += Math.Pow(baseNumber, j-1);
                            count++;
                        }
                        answerConverted += answerConverting.ToString();
                    }
                }
            }
            else if (optionNumber == 4)
            {
                baseNumber = 2;
                IntCheck();

                for (int i = 0; i < answerUser.Length; i++)
                {
                    
                    double valueToConvert = answerUser[i] - '0';
                    for (int j = 3; j > 0; j--)
                    {
                        if (Math.Pow(baseNumber, j-1) <= valueToConvert)
                        {
                            valueToConvert -= Math.Pow(baseNumber, j-1);
                            answerConverted += "1";
                        }
                        else
                            answerConverted += "0";
                    }
                }
            }
                Console.WriteLine($"Le résultat est: {answerConverted}");
            answerConverted = "";
        }
    }
}
