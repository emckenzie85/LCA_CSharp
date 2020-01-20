using System;

namespace ManyMethods
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //hello();
            addition();
            catDog();
            oddEvent();
            inches();
            echo();
            killGrams();
            date();
            age();
            guess();
        }

        private static void hello()
        {
            Console.WriteLine("What is your name?");
            string Name = Console.ReadLine();
            Console.WriteLine("Adios! " + Name);
            Console.ReadKey();
        }

        private static void addition()
        {
            int Value1;
            int Value2;
            int Total;
            Console.WriteLine("Pick a number, 1-9: ");
            Value1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Pick a second number, 1-9: ");
            Value2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Total = Value1 + Value2;
            Console.WriteLine(Total);
        }

        private static void catDog()
        {
            Console.WriteLine("Do you like cats or dogs better? ");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "cats")
            {
                Console.WriteLine("Meow");
            }
            else if (userInput == "dogs")
            {
                Console.WriteLine("Bark");
            }
            else
            {
                catDog();
            }
            Console.WriteLine();
        }

        private static void oddEvent()
        {
            Console.WriteLine("Now pick any number ");
            int userInput = int.Parse(Console.ReadLine());
            if (userInput % 2 == 0)
            {
                Console.WriteLine("That Number Is Even \n");
            }
            else
            {
                Console.WriteLine("That Number Is Odd ");
            }
        }

        private static void inches()
        {
            Console.WriteLine("How tall are you in feet? ");
            double userInput = Convert.ToDouble(Console.ReadLine());
            double inch = userInput * 12;
            Console.WriteLine("You are {0} inches tall!", inch);
        }

        private static void echo()
        {
            Console.WriteLine("Now type any word to witness an echo effect");
            string userInput = Console.ReadLine();
            string upper = userInput.ToUpper();
            string lower = userInput.ToLower();
            Console.WriteLine(upper + " " + " " +
                lower + " " + lower);
        }

        private static void killGrams()
        {
            Console.WriteLine("What is your weight in pounds (numbers only)?");
            double userInput = Convert.ToDouble(Console.ReadLine());
            double kilograms = userInput / 2.2;
            Console.WriteLine("Your weight in kilograms is + {0}", kilograms);
        }

        private static void date()
        {
            Console.WriteLine("The current date is: ");
            Console.WriteLine(DateTime.Now);
        }

        private static void age()
        {
            Console.WriteLine("What is your birth year? ");
            //Grabs user input and converts to double datatype
            double userInput = Convert.ToDouble(Console.ReadLine());
            DateTime currentyear = DateTime.Today;
            double age = currentyear.Year - userInput;
            Console.WriteLine("You are {0} years old!", age);
        }

        private static void guess()
        {
            Console.WriteLine("Guess a word involving csharp ");
            string userInput = Console.ReadLine();
            if (userInput == "csharp")
            {
                Console.WriteLine("Correct!!!");
            }
            else
            {
                Console.WriteLine("Try Again!!!");
                guess();
            }
        }
    }
}