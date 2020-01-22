using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Do you choose rock, paper or scissors? ");
            string userChoice = Console.ReadLine();

            Random r = new Random();
            int computerChoice = r.Next(4);

            if (computerChoice == 1)
            {
                if (userChoice == "rock")
                {
                    Console.WriteLine("The system chose rock");
                    Console.WriteLine("Tie! ");
                }
                else if (userChoice == "paper")
                {
                    Console.WriteLine("The system chose paper");
                    Console.WriteLine("Tie! ");

                }
                else if (userChoice == "scissors")
                {
                    Console.WriteLine("The system chose scissors");
                    Console.WriteLine("Tie! ");
                }
                else
                {
                    Console.WriteLine("Only rock, paper, or scissors will be accepted as an answer ");

                }

            }

            else if (computerChoice == 2)
            {
                if (userChoice == "rock")
                {
                    Console.WriteLine("The system chose paper ");
                    Console.WriteLine("Paper covers rock, you lose! ");

                }
                else if (userChoice == "paper ")
                {
                    Console.WriteLine("The system chose scissors ");
                    Console.WriteLine("Scissors cut paper, you lose! ");

                }
                else if (userChoice == "scissors ")
                {
                    Console.WriteLine("The system chose rock ");
                    Console.WriteLine("Rock breaks scissors, you lose! ");
                }
                else
                {
                    Console.WriteLine("Only rock, paper, or scissors will be accepted as an answer! ");
                }
            }
            else if (computerChoice == 3)
            {
                if (userChoice == "rock")
                {
                    Console.WriteLine("The system chose scissors ");
                    Console.WriteLine("Rock breaks scissors, You Win!!! ");

                }
                else if (userChoice == "paper")
                {
                    Console.WriteLine("The system chose rock ");
                    Console.WriteLine("Paper covers rock, You Win!!! ");

                }
                else if (userChoice == "scissors")
                {
                    Console.WriteLine("The system chose paper");
                    Console.WriteLine("Scissors cut paper, You Win!!! ");

                }
                else
                {
                    Console.WriteLine("Only rock, paper, or scissors will be accepted as an answer! ");

                }

            }

            Console.ReadLine();
        }
    }
}