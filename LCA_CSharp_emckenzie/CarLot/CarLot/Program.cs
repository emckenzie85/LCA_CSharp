using System;
using System.Collections.Generic;

namespace CarLot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Westheimer Imports CarLot
            CarLot Westheimer = new CarLot("Westheimer Imports", new List<Vehicle>());

            Vehicle WCar1 = new Car("Mercedes-Benz", "SL550-AMG", "Coupe", "2", "MBSL550", "$85,000");
            Vehicle WCar2 = new Truck("Ford", "F-150 Raptor", "8ft", "FFR1234", "$78,000");
            Vehicle WCar3 = new Car("Porsche", "Cayenne", "SUV", "4", "2LEG1T", "$46,000");

            //Slick's Slimey Car Sale CarLot
            CarLot Slicks = new CarLot("Slick's Slimey Car Sales", new List<Vehicle>());

            Vehicle Svehicle1 = new Car("Geo", "Metro", "Hatchback", "4", "GB123RD", "$850");
            Vehicle Svehicle2 = new Car("Chrysler", "LeBaron", "Coupe", "2", "1BADR1DE", "$1,000");
            Vehicle Svehicle3 = new Truck("Ford", "Ranger", "4ft", "00PZ4DAT", "$1,200");

            Westheimer.AddVehicle(WCar1);
            Westheimer.AddVehicle(WCar2);
            Westheimer.AddVehicle(WCar3);

            Westheimer.PrintList();

            Slicks.AddVehicle(Svehicle1);
            Slicks.AddVehicle(Svehicle2);
            Slicks.AddVehicle(Svehicle3);

            Slicks.PrintList();

            Console.ReadLine();
        }
    }

    internal class CarLot
    {
        private string Name { get; set; }
        public List<Vehicle> CarList { get; set; }

        public CarLot(string iName, List<Vehicle> iCarList)
        {
            Name = iName;
            CarList = iCarList;
        }

        public virtual void AddVehicle(Vehicle vehicle)
        {
            CarList.Add(vehicle);

        }

        public void PrintList()
        {
            Console.WriteLine("{0} Lot Inventory List:", Name);
            foreach (Vehicle vehicle in CarList)
            {
                Console.WriteLine(vehicle.Description());
            }
            Console.WriteLine("-----------------");
        }
    }

    //Abstract vehicle class
    internal abstract class Vehicle
    {
        public string LicenseNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }

        public Vehicle()
        {
        }

        public Vehicle(string iMake, string iModel, string iLicenseNumber, string iPrice)
        {
            Make = iMake;
            Model = iModel;
            LicenseNumber = iLicenseNumber;
            Price = iPrice;
        }

        public virtual string Description()
        {
            return $"\nCarID:{LicenseNumber}\nMake/Model:{Make} {Model}\nPrice:{Price}\n";
        }
    }

    internal class Truck : Vehicle
    {
        private string BedSize { get; set; }

        public override string Description()
        {
            return $"\nCarID:{LicenseNumber}\nMake/Model:{Make} {Model}\nBed size:{BedSize}\nPrice:{Price}\n";
        }

        public Truck(string iMake, string iModel, string iBed, string iLicenseNumber, string iPrice) : base(iMake, iModel, iLicenseNumber, iPrice)
        {
            BedSize = iBed;

        }
    }

    class Car : Vehicle
    {
        string Type { get; set; }
        string DoorCount { get; set; }

        public override string Description()
        {
            return $"\nCarID:{LicenseNumber}\nMake/Model:{Make} {Model}\nStyle:{Type}\n{DoorCount} door\nPrice:{Price}\n";
        }

        public Car(string iMake, string iModel, string iType, string iDoorCount, string iLicenseNumber, string iPrice) : base(iMake, iModel, iLicenseNumber, iPrice)
        {
            Type = iType;
            DoorCount = iDoorCount;
        }
    }
}
