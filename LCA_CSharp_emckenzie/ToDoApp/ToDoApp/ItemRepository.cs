using System.Collections.Generic;
using System.Linq;

namespace ToDoApp
{
    internal class ItemRepository
    {
        //Instantiates instance of context
        public static ItemContext context = new ItemContext();

        public ItemRepository()
        {
            //When ItemRepository is instantiated, confirms context table exists
            //If not, a new table is created
            context.Database.EnsureCreated();
        }

        #region AddItems Method
        public static void AddItem(string description)
        {
            //Creates new instance of ToDoItem Class
            //Adds new instance to context(table)
            ToDoItem todoItem = new ToDoItem(description);
            context.Add(todoItem);

            //Saves context
            context.SaveChanges();
        }
        #endregion

        #region DeleteItem Method
        public void DeleteItem(int ItemID)
        {
            //LINQ finds entry by matching ID entered by user with information in dataset
            //Removes the correct item from dataset
            //Saves changes to the dataset
            ToDoItem DeleteItem = context.ToDoList.Where(x => x.ID == ItemID).FirstOrDefault();
            context.Remove(DeleteItem);
            context.SaveChanges();
        }
        #endregion

        #region UpdateItem Method
        public void UpdateItem(int itemID, string description, string status)
        {
            //LINQ locates the ID entered by user
            ToDoItem UpdatedToDoItem = context.ToDoList.Where(x => x.ID == itemID).FirstOrDefault();

            //Description is updated if string entered is NOT empty
            if (description != "")
            {
                UpdatedToDoItem.Description = description;
            }
            //Status is updated if string entered is NOT empty
            if (status != "")
            {
                UpdatedToDoItem.Status = status;
            }
            //Updates dataset and saves changes 
            context.Update(UpdatedToDoItem);
            context.SaveChanges();
        }
        #endregion

        #region GetItems Method
        //List will be displayed based on filter entered by user
        public List<ToDoItem> GetItems(string filterCmd)
        {
            List<ToDoItem> LowLvlList = new List<ToDoItem>().ToList();
            if (filterCmd == "All")
            {
                LowLvlList = context.ToDoList.ToList();
            }
            else
            {
                if (filterCmd == "Complete")
                {
                    LowLvlList = context.ToDoList.Where(x => x.Status == filterCmd).ToList();
                }
                else if (filterCmd == "Incomplete")
                {
                    LowLvlList = context.ToDoList.Where(x => x.Status == filterCmd).ToList();
                }
            }
            return LowLvlList;
        }
        #endregion

        public bool ItemIDVerify(int itemID)
        {
            bool verifyID = context.ToDoList.Any(x => x.ID == itemID);
            return verifyID;
        }

        public void QuitProtocol()
        {
            context.SaveChanges();
        }
    }
}