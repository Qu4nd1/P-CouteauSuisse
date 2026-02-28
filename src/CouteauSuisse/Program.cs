using CouteauSuisse.Display;
using CouteauSuisse.Features;

namespace CouteauSuisse
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Main program
            bool running = true;

            Menu menu = new Menu();
            Morse morse = new Morse();
            ConversionBase conversionBase = new ConversionBase();
            Steganographie steganographie = new Steganographie();
            Verifications verifications = new Verifications();
            
            while (running)
            {
                menu.Init();
                int menuChoice = menu.RunInteractive();

                if (menu.Options[menuChoice - 1] == "Quit")
                {
                    running = false;
                }
                else
                {
                    menu.HandleChoice(menuChoice, morse, conversionBase, steganographie, verifications);
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey(true);
                }
            }
        }

    }
}
