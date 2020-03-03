using System.Collections.Generic;

namespace ToDoApp
{
    internal class App
    {
        private ItemRepository Itemrepo;
        public ConsoleUtil ConsoleUtil;

        public App()
        {
            Itemrepo = new ItemRepository();
            ConsoleUtil = new ConsoleUtil();
        }
        #region DisplayAll Method
        //When "All" filter command is entered,
        //The appropriate methods from console and repo classes 
        //are called on to display all ToDoItems.
        private void DisplayAll()
        {
            string filterCmd = "All";

            List<ToDoItem> List = Itemrepo.GetItems(filterCmd);
            ConsoleUtil.PrintList(List);
        }
        #endregion

        #region DisplayFilter Method
        //The method that handles filtering
        //Calls the filter method from console to prompt filter selection
        //Switch statement handles multiple scenarios depending on command entered.
        private void DisplayFilter()
        {
            string filterCmd = "";
            string filter = ConsoleUtil.GetFilterType(filterCmd);

            switch (filter)
            {
                case "Complete":
                    List<ToDoItem> comList = Itemrepo.GetItems(filter);
                    ConsoleUtil.PrintList(comList);
                    break;

                case "Incomplete":
                    List<ToDoItem> incomList = Itemrepo.GetItems(filter);
                    ConsoleUtil.PrintList(incomList);
                    break;

                case "All":
                    List<ToDoItem> allList = Itemrepo.GetItems(filter);
                    ConsoleUtil.PrintList(allList);
                    break;

                default:
                    ConsoleUtil.BadFilter();
                    break;
            }
        }
        #endregion

        #region Start Method
        //Main driving method 
        public void Start()
        {
            //Calls DisplayAll method as well as the command list.
            DisplayAll();
            string command = ConsoleUtil.GetCommands();
            bool quit = false;
            bool update = false;
            string updateSelect = "";
            bool verifyID = true;
            bool verifyStat = true;

            //While the program is not in a "quit" state then run
            while (!quit)
            {
                //Ensures that the command given is actually valid
                CommandValidate(command);
                if (CommandValidate(command) == false)
                {
                    ConsoleUtil.BadAction();
                }

                //Switch statement handles command scenarios 
                switch (command)
                {
                    //Asks user for description of ToDo Item
                    //Once done, the item is generated and added to the list
                    case "Add":
                        update = true;
                        string newDesc = ConsoleUtil.GetDescription(update);
                        ItemRepository.AddItem(newDesc);
                        DisplayAll();
                        break;

                    case "Delete":
                        do
                        {
                            //Asks user to select ID and verifies ID to ensure it's valid.
                            int delItemID = ConsoleUtil.GetItemID(command);
                            verifyID = Itemrepo.ItemIDVerify(delItemID);
                            if (verifyID == false)
                            {
                                //If not valid, then calls BadID method
                                DisplayAll();
                                ConsoleUtil.BadID();
                            }
                            else
                            {
                                //If valid then call DeleteItem method with given ID 
                                //Then display updated list
                                Itemrepo.DeleteItem(delItemID);
                                DisplayAll();
                            }
                            //Ensures that this case is looped while ID is invalid
                        } while (!verifyID);
                        break;

                    case "Update":
                        do
                        {
                            update = true;
                            //User is asked to select an ID to update
                            int itemID = ConsoleUtil.GetItemID(command);
                            //Verifies ID is valid 
                            verifyID = Itemrepo.ItemIDVerify(itemID);
                            if (verifyID == false)
                            {
                                //If not, call BadID method to prompt user
                                ConsoleUtil.BadID();
                            }
                            else
                            {
                                //If ID is valid, prompts user to select either "description" or "status" to update
                                updateSelect = ConsoleUtil.UpdateSelect(itemID);

                                if (updateSelect == "description")
                                {
                                    //If "description" is selected then automatically set the status update to false
                                    bool statUpdate = false;
                                    //Grabs new description
                                    newDesc = ConsoleUtil.GetDescription(update);
                                    //Status stays the same
                                    string newStat = ConsoleUtil.GetStatus(statUpdate);
                                    //Generates updated ToDo Itm
                                    Itemrepo.UpdateItem(itemID, newDesc, newStat);
                                }
                                else if (updateSelect == "status")
                                {
                                    do
                                    {
                                        //If status is to be updated
                                        //Automatically sets "description" update to false 
                                        bool descUpdate = false;
                                        //Prompts user for new status and grabs string 
                                        string newStat = ConsoleUtil.GetStatus(update);
                                        //Verifies that it is a valid status
                                        verifyStat = StatusValidate(newStat);
                                        if (verifyStat == false)
                                        {
                                            //If not a valid status, prompts user to Bad Status
                                            ConsoleUtil.BadStatus();
                                        }
                                        else
                                        {
                                            //If valid then description stays the same then generates updated ToDo Item
                                            newDesc = ConsoleUtil.GetDescription(descUpdate);
                                            Itemrepo.UpdateItem(itemID, newDesc, newStat);
                                        }
                                        //While loop ensures that case is looped while an invalid status persists   
                                    } while (verifyStat == false);
                                }
                                //Anything other than "description" or "status" will result in the invalid action prompt
                                //And sets the verifyID to false so the case will get looped again 
                                else
                                {
                                    ConsoleUtil.BadAction();
                                    verifyID = false;
                                }
                            }
                            //While loop ensures Update case is looped while ID is invalid 
                        } while (!verifyID);
                        //Displays the list with updated items
                        DisplayAll();
                        break;

                    case "Filter":
                        //Runs DisplayFilter method and that method handles everything for this case
                        DisplayFilter();
                        break;

                    case "Quit":
                        //Calls the QuitProtocol and sets quit to be true so it can exit out of the program loop
                        Itemrepo.QuitProtocol();
                        quit = true;
                        break;
                }
                if (quit == true)
                {
                    //Then prompts user with exit message
                    ConsoleUtil.QuitMessage();
                }
                else
                {
                    //Still uses the program then displays commands
                    command = ConsoleUtil.GetCommands();
                }
            }
        }
        #endregion

        //Validation protocols listed below:

        #region CommandValidate Protocol
        public static bool CommandValidate(string command)
        {
            //Ensures that the commands given are actually valid commands.
            bool valid = false;
            if (command.ToLower() == "done" || command.ToLower() == "add" || command.ToLower() == "delete" || command.ToLower() == "update" ||
                command.ToLower() == "filter" || command.ToLower() == "quit")
            {
                valid = true;
            }
            return valid;
        }
        #endregion

        #region StatusValidate Protocol
        public static bool StatusValidate(string status)
        {
            //Ensures that the statuses given are actually valid.
            bool valid = false;
            if (status.ToLower() == "complete" || status.ToLower() == "incomplete")
            {
                valid = true;
            }
            return valid;
        }
        #endregion

    }
}