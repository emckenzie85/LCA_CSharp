using System;
using System.Collections.Generic;

namespace ToDoItems
{
    internal class ToDo
    {
        private static List<todoItem> ToDoList = new List<todoItem>();

        private static bool quitProgram = false;

        private static bool continueProgram = true;

        private static void Main(string[] args)
        {
            Console.WriteLine("Press 'Enter' if you would like to add an item\nOr press 'Q' to quit");

            string quitInput = Console.ReadLine();
            quitInput.ToLower();

            do
            {
                if (quitInput == "q")
                {
                    quitProgram = true;
                    Console.WriteLine("See you next time!");
                }
                else if (continueProgram == true)
                {
                    Console.WriteLine("\nEnter a description of the item:");
                    string userTask = Console.ReadLine();

                    Console.WriteLine("\nEnter the due date of the item: ");
                    string userDueDate = Console.ReadLine();

                    Console.WriteLine("\nEnter the priority level of the item: (High, Normal, Low)");
                    string userPriority = Console.ReadLine();

                    todoItem userItem = new todoItem(userTask, userDueDate, userPriority);

                    ToDoList.Add(userItem);

                    Console.WriteLine("\nWould you like to enter another item?");
                    string newItemInput = Console.ReadLine();
                    newItemInput.ToLower();

                    if (newItemInput == "yes" || newItemInput == "Yes")
                    {
                        continueProgram = true;
                    }
                    else
                    {
                        foreach (todoItem Item in ToDoList)
                        {
                            Item.printItem();

                        }

                        Console.ReadLine();
                        quitProgram = true;

                    }
                }
            } while (quitProgram == false);
        }

        public class todoItem
        {
            public string Description { get; set; }
            public string DueDate { get; set; }
            public string Priority { get; set; }

            public todoItem(string Description, string DueDate, string Priority)
            {
                this.Description = Description;
                this.DueDate = DueDate;
                this.Priority = Priority;
            }

            public void printItem()
            {
                Console.WriteLine("\n{0} | {1} | {2}\n", Description, DueDate, Priority);
            }

        }
    }
}