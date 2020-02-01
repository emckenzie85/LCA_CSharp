using System;
using System.Collections.Generic;

class ConsoleApplication1
{
    public static void Main()
    {
        List<Student> students = new List<Student>();

        for (int index = 0; index < 5; index++)
        {
            Student newStudent = new Student();
            Console.Write("Enter Student's Name or 'QUIT' : ");
            string name = Console.ReadLine();
            if (name == "QUIT")
                break;
                List<Exam> grades = new List<Exam>();

            for (int jIndx = 0; jIndx < 5; jIndx++)
            {
                Console.Write("Enter Student's Grades with Spaces Between (100 90 80 70 60): ");
                int grade = int.Parse(Console.ReadLine());
                Exam res = new Exam();
                res.Grade = grade;
                grades.Add(res);
            }

            newStudent.Name = name;
            newStudent.Result = grades;
            students.Add(newStudent);
        }
        {
            Console.WriteLine("Subject: " + exam.Subject);
            Console.WriteLine("Grade: " + exam.Grade);
        }
    }
}

public class Student
{
    public string Name { get; set; }
    public List<Exam> Result { get; set; }
}

public class Exam
{
    public string Subject { get; set; }
    public int Grade { get; set; }
}