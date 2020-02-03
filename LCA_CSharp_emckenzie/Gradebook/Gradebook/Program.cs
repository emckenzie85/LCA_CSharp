using System;
using System.Collections.Generic;
using System.Linq;

namespace GR4D3B00K
{
    class Program
    {
        private static void Main(string[] args)
        {

            string answer = string.Empty;
            string quitProgram = string.Empty;
            Dictionary<string, string> gradeBook = new Dictionary<string, string>();
            string[] seperator = { " " };

            do
            {
                Console.WriteLine("\nPlease enter student's name or QUIT\n");
                string studentName = Console.ReadLine();
                if (studentName == "QUIT")
                    break;

                Console.WriteLine("\nNow enter student's grades, seperated by spaces (100 90 80 90 70) then press ENTER\n");
                string studentGrades = Console.ReadLine();

                gradeBook.Add(studentName, studentGrades);

                Console.WriteLine("\n Press ENTER to add another student, or type 'C' to continue");
                answer = Console.ReadLine();

            } while (answer != "C");

            List<int> gradeList = new List<int>();
            List<int> total = new List<int>();

            int totalGrade;
            int avgGrade;
            int highGrade;
            int lowGrade;

            foreach (KeyValuePair<string, string> entry in gradeBook)
            {

                String[] gradeArray = entry.Value.Split(" ");
                lowGrade = Convert.ToInt32(gradeArray.Min());
                highGrade = Convert.ToInt32(gradeArray.Max());


                for (int i = 0; i < gradeArray.Length; i++)
                {
                    total.Add(Convert.ToInt32(gradeArray[i]));
                }

                totalGrade = total.Sum();
                avgGrade = totalGrade / gradeArray.Length;

                Console.WriteLine("Student: {0}", entry.Key);
                Console.WriteLine("Grades: {0}", entry.Value);
                Console.WriteLine("High: {0} Low: {1} ", highGrade, lowGrade);
                Console.WriteLine("Grade Average: {0}", avgGrade);

            }
        }
    }
}