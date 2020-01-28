using System;
using System.Collections.Generic;
using System.Linq;

namespace Mastermind 
{
    internal class Program
    {
        private static List<string> colors = new List<string> { "red", "yellow", "blue" };
        private static Random CPUselect = new Random();

        private static bool WinCheck = false;

        private static void Main(string[] args)
        {
            Console.WriteLine("W3LC0M3 T0 M4$T3RM1ND!\nThe system will choose 2 of the 3 colors at random (Red, Yellow, and Blue):\nNow it's your turn to figure out what two were chosen, pick two colors!\n"); 
            int colorIndex = CPUselect.Next(colors.Count);
            var color1 = colors[colorIndex];
            colorIndex = CPUselect.Next(colors.Count);
            var color2 = colors[colorIndex];

            string[] CPUcolors = { color1, color2 };
            string[] UserGuess = Console.ReadLine().Split(" ");

            while (!WinCheck)
            {
                UserGuess.SequenceEqual(CPUcolors, StringComparer.CurrentCultureIgnoreCase);
                if (UserGuess.Contains("red") || UserGuess.Contains("yellow") || UserGuess.Contains("blue") || UserGuess.Length < 0)
                {
                    Console.WriteLine("\nMake sure you are using correct casing, spelling and spacing.\nYou must type in 2 colors (Red, Yellow, or Blue), seperated by a space\nTry again.\n");
                    UserGuess = Console.ReadLine().Split(" ");
                }
                else if (UserGuess[0] != CPUcolors[0] && UserGuess[1] != CPUcolors[1] && UserGuess[0] != CPUcolors[1] && UserGuess[1] != CPUcolors[0])
                {
                    Console.WriteLine("\nHint: 0-0\n \nTry again");
                    UserGuess = Console.ReadLine().Split(" ");
                }
                else if (UserGuess[0] == CPUcolors[1] && UserGuess[1] != CPUcolors[0])
                {
                    Console.WriteLine("\nHint: 1-0\n \nTry again");
                    UserGuess = Console.ReadLine().Split(" ");
                }
                else if (UserGuess[0] == CPUcolors[0] && UserGuess[1] != CPUcolors[1] || UserGuess[1] == CPUcolors[1] && UserGuess[0] != CPUcolors[0])
                {
                    Console.WriteLine("\nHint: 0-1\n \nTry again");
                    UserGuess = Console.ReadLine().Split(" ");
                }
                else if (UserGuess[0] == CPUcolors[1] && UserGuess[1] == CPUcolors[0])
                {
                    Console.WriteLine("\nHint: 2-0\n \nTry again");
                    UserGuess = Console.ReadLine().Split(" ");
                }
                else
                {
                    WinCheck = true;
                    Console.WriteLine("\nYou Guessed Correctly, You Win! ");
                    Console.ReadLine();
                }
            }
        }
    }
}
