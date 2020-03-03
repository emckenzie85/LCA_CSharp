using System;
using System.IO;
using Microsoft.EntityFrameworkCore;


namespace ToDoApp
{
    class ItemContext : DbContext
    {
        //Database set of ToDoItems, a list (table) of ToDoItems
        public DbSet<ToDoItem> ToDoList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Locates the directory that is executing the code
            DirectoryInfo ExecutionDirectory = new DirectoryInfo(AppContext.BaseDirectory);

            //Locates the base directory for the project
            DirectoryInfo ProjectBase = ExecutionDirectory.Parent.Parent.Parent;

            //Add 'students.db' to the project directory
            String DatabaseFile = Path.Combine(ProjectBase.FullName, "todoItems.db");

            //To check the path of the file, uncomment the file below (remove '//')
            //Console.WriteLine("Using Database File :"+DatabaseFile);

            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }
    }
}