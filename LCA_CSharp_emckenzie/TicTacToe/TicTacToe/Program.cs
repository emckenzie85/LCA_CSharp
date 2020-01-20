using System;

using System.Threading;


namespace TicTacToe

{

    class Program

    {

        //Making Array and   

        //by default I am providing 0-9 where there is no use of zero  

        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static int player = 1; //By default player 1 is set  

        static int choice; //This holds the choice at the space user wants to mark   



        // The flag variable checks to see who has won, if its value is 1 then there is a winner, if -1 then the match is tied, if 0 then match is still in play

        static int flag = 0;



        static void Main(string[] args)

        {

            do

            {

                Console.Clear();// whenever loop starts again the screen will be clear  

                Console.WriteLine("Player1:X and Player2:O");

                Console.WriteLine("\n");

                if (player % 2 == 0)//checking the turn of the player  

                {

                    Console.WriteLine("Player 2 Turn");

                }

                else

                {

                    Console.WriteLine("Player 1 Turn");

                }

                Console.WriteLine("\n");

                Board();// calling the board Function  

                choice = int.Parse(Console.ReadLine());//Player's decision   



                // checking if the position where user wants to mark is claimed or not  

                if (arr[choice] != 'X' && arr[choice] != 'O')

                {

                    if (player % 2 == 0) //if player 2's turn then mark O, otherwise mark X  

                    {

                        arr[choice] = 'O';

                        player++;

                    }

                    else

                    {

                        arr[choice] = 'X';

                        player++;

                    }

                }

                else //If there is any position where the user wants to mark that has already been claimed, show this message and load the board again  

                {

                    Console.WriteLine("Sorry, row {0} is already marked with {1}", choice, arr[choice]);

                    Console.WriteLine("\n");

                    Console.WriteLine("The board will load again in 2 seconds...");

                    Thread.Sleep(2000);

                }

                flag = CheckWin();// calling of checkWin  

            } while (flag != 1 && flag != -1);// This will be run until the board is wiped clean  



            Console.Clear();// will clear the console  

            Board();// board is filled again 



            if (flag == 1)// if flag value is 1 the last person to play has won 

            {

                Console.WriteLine("Player {0} has won", (player % 2) + 1);

            }

            else// if flag value is -1 the match will be tied and nobody wins  

            {

                Console.WriteLine("Draw!!!");

            }

            Console.ReadLine();

        }

        // Board method will create board  

        private static void Board()

        {

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);

            Console.WriteLine("     |     |      ");

        }



        //Checking if a player wins or not  

        private static int CheckWin()

        {

            #region Horzontal Winning Condtion

            //Winning Condition For First Row   

            if (arr[1] == arr[2] && arr[2] == arr[3])

            {

                return 1;

            }

            //Winning Condition For Second Row   

            else if (arr[4] == arr[5] && arr[5] == arr[6])

            {

                return 1;

            }

            //Winning Condition For Third Row   

            else if (arr[6] == arr[7] && arr[7] == arr[8])

            {

                return 1;

            }

            #endregion



            #region vertical Winning Condtion

            //Winning Condition For First Column       

            else if (arr[1] == arr[4] && arr[4] == arr[7])

            {

                return 1;

            }

            //Winning Condition For Second Column  

            else if (arr[2] == arr[5] && arr[5] == arr[8])

            {

                return 1;

            }

            //Winning Condition For Third Column  

            else if (arr[3] == arr[6] && arr[6] == arr[9])

            {

                return 1;

            }

            #endregion



            #region Diagonal Winning Condition

            else if (arr[1] == arr[5] && arr[5] == arr[9])

            {

                return 1;

            }

            else if (arr[3] == arr[5] && arr[5] == arr[7])

            {

                return 1;

            }

            #endregion



            #region Checking For Tie

            // If all the cells or values are filled with X or O then that player wins the match  

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')

            {

                return -1;

            }

            #endregion



            else

            {

                return 0;

            }

        }

    }

}