using System;
using System.Collections.Generic;

namespace PoCos
{
    class Program
    {
        static void Main(string[] args)
        {   //Driver's License Instance
            DriverLicense driver1 = new DriverLicense("Joe", "Schmoe", "Male", "12345555");
            string FullName = driver1.GetFullName();
            Console.WriteLine(FullName);

            //Book Instance
            Book book1 = new Book("The Greasy Gatsby", "Melvin Feinstein", "Molly Ringwold", "710", "58756-120", "Barnes & Noble Press", "$24.95");
            string Authors = book1.GetAuthors();
            Console.WriteLine(Authors);

            //Plane Instance
            Airplane airplane1 = new Airplane("Boeing", "Stealth Bomber", "Variant 6", "Variant 3", "2", "3");
            Console.WriteLine("The {0} {1} {2},{3}, holds {4} passengers and has {5} engines!", airplane1.Manufacturer, airplane1.Model, airplane1.Variant1, airplane1.Variant2, airplane1.Capacity, airplane1.Engines);
            string Variants = airplane1.GetVariants();
            Console.WriteLine(Variants);
        }

        public class DriverLicense
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public string LicenseNumber { get; set; }
            public string GetFullName()
            {
                string FullName = FirstName + LastName;

                return FullName;
            }

            public DriverLicense(string initialFirst, string initialLast, string initialGender, string initialLicenseNumber)
            {
                FirstName = initialFirst;
                LastName = initialLast;
                Gender = initialGender;
                LicenseNumber = initialLicenseNumber;

            }

        }

        public class Book
        {
            public string Title { get; set; }
            public string Author1 { get; set; }
            public string Author2 { get; set; }
            public string Pages { get; set; }
            public string SKU { get; set; }
            public string Publisher { get; set; }
            public string Price { get; set; }
            public string GetAuthors()
            {
                string Authors = Author1 + Author2;

                return Authors;
            }

            public Book(string initialTitle, string initialAuthor1, string initialAuthor2, string initialPages, string initialSKU, string initialPublisher, string initialPrice)
            {
                Title = initialTitle;
                Author1 = initialAuthor1;
                Author2 = initialAuthor2;
                Pages = initialPages;
                SKU = initialSKU;
                Publisher = initialPublisher;
                Price = initialPrice;
            }
        }

        public class Airplane
        {
            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public string Variant1 { get; set; }
            public string Variant2 { get; set; }
            public string Capacity { get; set; }
            public string Engines { get; set; }
            public string GetVariants()
            {
                string Variants = Variant1 + Variant2;

                return Variants;
            }

            public Airplane(string initialManufacturer, string initialModel, string initialVariant1, string initialVariant2, string initialCapacity, string initialEngines)
            {
                Manufacturer = initialManufacturer;
                Model = initialModel;
                Variant1 = initialVariant1;
                Variant2 = initialVariant2;
                Capacity = initialCapacity;
                Engines = initialEngines;
            }
        }
    }
}
