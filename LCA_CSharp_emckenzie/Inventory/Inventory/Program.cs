using System;
using System.Collections.Generic;

namespace Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List of Instantiated Items
            List<IRentable> Inventory = new List<IRentable>();

            //Boat Options
            Boat Boat1 = new Boat("$85.00", "\nSeaDoo Jet-Ski");
            Boat Boat2 = new Boat("250.00", "\nSpeedBoat");
            //House Options
            House House1 = new House("$1,500", "\nLuxury condo in Venice Beach, California");
            House House2 = new House("$750.00", "\nCabin in Breckenridge, Colorado");
            //Car Options 
            Car Vehicle1 = new Car("$750.00", "\nFerrari 488");
            Car Vehicle2 = new Car("$65.00", "\nNissan 350z"); 

            //Adding Items to Inventory List
            Inventory.Add(Vehicle1);
            Inventory.Add(Vehicle2);
            Inventory.Add(House1);
            Inventory.Add(House2);
            Inventory.Add(Boat1);
            Inventory.Add(Boat2);

            //Gives the rates and descriptions of all Items
            foreach(IRentable item in Inventory)
            {
                item.GetDescription();
                item.GetRate();
            }
            Console.ReadLine();
        }

        interface IRentable
        {
            //Abstract Methods
            void GetRate();
            void GetDescription();
        }

        //classes extends interface
        class Boat : IRentable
        {
            string Rate { get; set; }
            string Description { get; set; }

            public Boat(string HourlyRate, string iDescription)
            {
                Rate = HourlyRate;
                Description = iDescription;
            }

            public void GetRate()
            {
                Console.WriteLine("{0} Per Hour", Rate);
            } 

            public void GetDescription()
            {
                Console.WriteLine("{0}", Description);
            }

        }

        class House : IRentable
        {
            string Rate { get; set; }
            string Description { get; set; }

            public House(string WeeklyRate, string iDescription)
            {
                Rate = WeeklyRate;
                Description = iDescription;
            }

            public void GetRate()
            {
                Console.WriteLine("{0} Per Week", Rate);
            }

            public void GetDescription()
            {
                Console.WriteLine("{0}", Description);
            }
        }

        class Car : IRentable
        {
            string Rate { get; set; }
            string Description { get; set; }

            public Car(string DailyRate, string iDescription)
            {
                Rate = DailyRate;
                Description = iDescription;
            }

            public void GetRate()
            {
                Console.WriteLine("{0} Per Day", Rate);
            }

            public void GetDescription()
            {
                Console.WriteLine("{0}", Description);
            }
        }
    }
}
