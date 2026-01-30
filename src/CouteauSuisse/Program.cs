using Microsoft.VisualBasic;
using CouteauSuisse.Display;

namespace CouteauSuisse
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Main program
            bool running = true;

            while (running)
            {
                Menu.Init();
                int menuChoice = Menu.RunInteractive();

                if (Menu.Options[menuChoice - 1] == "Quit")
                {
                    running = false;
                }
                else
                {
                    Menu.HandleChoice(menuChoice);
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey(true);
                }
            }
        }

    }
}
