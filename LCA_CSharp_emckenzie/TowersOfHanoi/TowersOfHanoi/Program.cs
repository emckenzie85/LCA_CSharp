using System;
using System.Collections.Generic;
using System.Linq;

namespace TowersOfHanoi
{
    internal class Program
    {
        //BOARD
        private static Dictionary<string, Stack<int>> Gameboard = new Dictionary<string, Stack<int>>();

        //PEGS
        private static Stack<int> Apegs = new Stack<int>();

        private static Stack<int> Bpegs = new Stack<int>();
        private static Stack<int> Cpegs = new Stack<int>();

        //Bool Variable On Game Condition
        private static bool WinGame = false;

        private static void Main(string[] args)
        {
            //Rules of Game/Directions
            Console.WriteLine("TOWERS OF HANOI\n");
            Console.WriteLine("Towers Will Be Keys A, B, and C.\nNumbers 1-4 Are Pegs.\n");
            Console.WriteLine("~~~~~DIRECTIONS~~~~~");
            Console.WriteLine("1. Blocks can only be moved to the top of larger blocks.\n" +
                              "2. You may only move the top block.\n" +
                              "3. Win the game when the entire stack has been moved from the first tower to the third tower.");
            Console.WriteLine("~~~~~GOOD LUCK!!!~~~~~");

            //Initial Build of Game Board
            Apegs.Push(4);
            Apegs.Push(3);
            Apegs.Push(2);
            Apegs.Push(1);

            Gameboard.Add("A", Apegs);
            Gameboard.Add("B", Bpegs);
            Gameboard.Add("C", Cpegs);

            //Main Game Loop
            do
            {
                BuildBoard();
                UserInput();
                WinCheck();
            } while (WinGame == false);
        }

        #region BuildBoard

        public static void BuildBoard()
        {
            //This loops through Gameboard and displays Stack Keys and Values.
            foreach (var Tower in Gameboard)
            {
                Console.Write(Tower.Key);

                Console.WriteLine(string.Join(" ", Tower.Value.Reverse()));
            }
        }

        #endregion BuildBoard

        #region UserInput

        public static void UserInput()
        {
            //This asks user to select tower to move from.
            Console.WriteLine("Select a tower to move from: ");
            string fromTower = Console.ReadLine().ToUpper();

            //This asks user to select tower it will move to.
            Console.WriteLine("Select the tower you would like to move to: ");
            string toTower = Console.ReadLine().ToUpper();

            Console.WriteLine("\n");

            //This runs MoveCheck method and then performs MakeMove() method if the return is true.
            if (MoveCheck(fromTower, toTower))
            {
                MakeMove(fromTower, toTower);
            }
            else
            {
                //This will give the user an invalid move message if the return is false.
                Console.WriteLine("Sorry, your move was invalid. Try again.");
                return;
            }
        }

        #endregion UserInput

        #region MoveCheck

        public static bool MoveCheck(string fromTower, string toTower)
        {
            //New stack<int> variable is taken from the user input.
            Stack<int> fromStack = Gameboard[fromTower];
            Stack<int> toStack = Gameboard[toTower];

            //If the user inputs equal one another, the move is illegal.
            if (fromTower == toTower)
            {
                return false;
            }
            //If the user input targets an empty stack to take from, the move is illegal.
            else if (fromStack.Count == 0)
            {
                return false;
            }
            //If the user input targets an empty stack to move to, the move is legal.
            else if (toStack.Count == 0)
            {
                return true;
            }
            else
            {
                //Int variables derived from the top number of the stacks being selected.
                int toValue = Gameboard[toTower].Peek();
                int fromValue = Gameboard[fromTower].Peek();

                //If the top number of the fromTower is greater than the top number in the toTower the move is illegal.
                if (fromValue > toValue)
                {
                    return false;
                }
                //Otherwise, the move is legal.
                return true;
            }
        }

        #endregion MoveCheck

        #region MakeMove

        public static void MakeMove(string fromTower, string toTower)
        {
            //This int variable derived from the popped number from the fromTower.
            int fromPeg = Gameboard[fromTower].Pop();

            //This pushes the popped number to the toTower destination.
            Gameboard[toTower].Push(fromPeg);
        }

        #endregion MakeMove

        #region Wincheck
        public static void WinCheck()
        {
            //If the C Tower has total of 4 pegs then user wins.
            if (Cpegs.Count == 4)
            {
                Console.WriteLine("You Win!");
                WinGame = true;
            }
            //If not, the game is still in progress.
            else { WinGame = false; }
        }
        #endregion
    }
}