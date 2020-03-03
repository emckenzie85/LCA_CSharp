using System;
using System.Collections.Generic;
using System.Globalization;

namespace ToDoApp
{
    internal class ConsoleUtil
    {
        public ConsoleUtil()
        {
        }
        #region PrintList Method
        //Prints out list with current dataset
        public List<ToDoItem> PrintList(List<ToDoItem> ConsoleList)
        {
            Console.Clear();
            Console.WriteLine("***** To Do List *****");
            Console.WriteLine("(ID | Description | Status)");
            Console.WriteLine();
            foreach (ToDoItem i in ConsoleList)
            {
                Console.WriteLine($"{i.ID} | {i.Description} | {i.Status}");
            }
            Console.WriteLine();
            return ConsoleList;
        }
        #endregion

        #region GetCommands Method
        //Prints commands for the user to enter
        public string GetCommands()
        {
            Console.WriteLine("\nType the command in parenthesis you would like to execute.");
            Console.WriteLine("(Add) item  | (Delete) item | (Update) item");
            Console.WriteLine("(Filter) list | (Quit) program");
            string action = Console.ReadLine();
            string UserCmd = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(action);

            return UserCmd;
        }
        #endregion

        #region UpdateSelect Method
        //Prompts user after 'update' command is entered.
        public string UpdateSelect(int itemID)
        {
            Console.WriteLine("Would you like to update the Item's Description or Status? (Type 'description' or 'status')");
            string select = Console.ReadLine().ToLower();

            return select;
        }
        #endregion

        #region GetDescription Method
        //Prompts the user to enter item's description. 
        //The else statement is used to help get around a redundancy late in the development process.
        //If the user only wants to update the item's status it will skip the description update altogether.
        public static string GetDescription(bool descUpdate)
        {
            if (descUpdate == true)
            {
                Console.WriteLine("\nEnter the description of the task/job.\n");
            }
            else
            {
                Console.WriteLine("Press [ENTER] to continue.");
            }
            string description = Console.ReadLine();
            return description;
        }
        #endregion

        #region GetStatus Method
        //Prompts user to update the status.
        //The else statement helps to avoid redundancy if only the status needs to be updated, bypassing the description.
        public static string GetStatus(bool statUpdate)
        {
            if (statUpdate == true)
            {
                Console.WriteLine("Enter item's status: Complete or Incomplete");
            }
            else
            {
                Console.WriteLine("Press [ENTER] to continue.");
            }
            string userInput = Console.ReadLine();
            string status = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userInput);
            return status;
        }
        #endregion

        #region GetItemID Method
        //Grabs item's ID
        //Method will prompt user when they enter 'delete' or 'update'.
        public static int GetItemID(string option)
        {
            if (option.ToLower() == "update")
            {
                Console.WriteLine("\nEnter the item's ID you wish to update.\n");
            }
            else if (option.ToLower() == "delete")
            {
                Console.WriteLine("\nEnter the item's ID you wish to delete.\n");
            }
            else
            {
                ConsoleUtil.BadAction();
            }

            string userInput = Console.ReadLine();
            int itemID = int.Parse(userInput);

            return itemID;
        }
        #endregion

        #region GetFilterType Method
        //Prompts user to choose how to filter the list.
        public string GetFilterType(string filterCmd)
        {
            Console.WriteLine("How would you like to filter the list? Enter one of the following: All, Complete, or Incomplete. ");
            string filterInput = Console.ReadLine();
            string filterType = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(filterInput);
            return filterType;
        }
        #endregion

        #region QuitMessage Method
        //Prompts user that they are exiting program and their list is being saved.
        public static void QuitMessage()
        {
            Console.Clear();
            Console.WriteLine("\nExiting program, items are being saved...");
            Console.WriteLine("Goodbye!");
        }
        #endregion

        //Listed below are the console outputs for exception handling procedures.

        #region BadID Prompt
        //Happens when invalid ID is entered.
        public static void BadID()
        {
            Console.WriteLine();
            Console.WriteLine("The ID you entered is invalid, please try again.");
            Console.WriteLine();
        }
        #endregion

        #region BadStatus Prompt
        //Happens when invalid status is entered.
        public static void BadStatus()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("The status you entered is invalid, please try again.");
            Console.WriteLine();
        }
        #endregion

        #region BadFilter Prompt
        //Happens when invalid filter is entered.
        public static void BadFilter()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("The filter type you have entered is invalid, please try again.");
            Console.WriteLine();
        }
        #endregion

        #region BadAction Prompt
        //Happens when an invalid action (command) is given.
        public static void BadAction()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("The action you have entered is invalid, please try again.");
            Console.WriteLine();
        }
        #endregion

    }
}