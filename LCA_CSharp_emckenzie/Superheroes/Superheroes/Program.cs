using System;
using System.Collections.Generic;

namespace Superheroes
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Person> People = new List<Person>();

            Person Bill = new Person("William S Preston Esquire", "Bill");
            Person Ted = new Person("Ted Theodore Logan", "Ted");
            Person Rufus = new Person("George Carlin", "Rufus");

            SuperHero MrIncredible = new SuperHero("MrIncredible,", "WadeTurner", "super strength", null);

            Villain TheJoker = new Villain("TheJoker", "Batman", null);

            People.Add(Bill);
            People.Add(Ted);
            People.Add(Rufus);
            People.Add(MrIncredible);
            People.Add(TheJoker);

            foreach (Person human in People)
            {
                human.Greeting();
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public Person()
        {
        }

        public Person(string iName, string iNickname)
        {
            Name = iName;
            Nickname = iNickname;
        }

        public virtual void Greeting()
        {
            Console.WriteLine("{0}: Hello, my name is {1} but my friends call me {2}.\n", Name, Name, Nickname);
        }
    }

    internal class SuperHero : Person
    {
        public string RealName { get; set; }
        public string SuperPower { get; set; }

        public SuperHero(string Name, string iRealName, string iSuperPower, string Nickname) : base(Name, Nickname)
        {
            SuperPower = iSuperPower;
            RealName = iRealName;
            Nickname = null;
        }

        public override void Greeting()
        {
            Console.WriteLine("{0}: I am {1}. When I am {2} I have {3}!\n", Name, RealName, Name, SuperPower);
        }
    }

    internal class Villain : Person
    {
        public string RealName { get; set; }
        public string Nemesis { get; set; }

        public Villain(string Name, string iNemesis, string Nickname): base(Name, Nickname)
        {
        Nemesis = iNemesis;
        Nickname = null;
        }

        public override void Greeting()
        {
            Console.WriteLine("{0}: I am {1}! Have you seen {2}?", Name, Name, Nemesis);
        }

    }
}
