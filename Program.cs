namespace Gradebook_Project;

 using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

class GradeBook
{
    public int studentcount;
    static void Main(string[] args)
    {
        Dictionary<string, List<int>> gradeBook = new Dictionary<string, List<int>>();
        bool running = true;
// Main menu
        while (running)
        {
            Console.WriteLine("/n--- Gradebook Menu ---");
            Console.WriteLine("1. Enter Student Name and Grades");
            Console.WriteLine("2. View Gradebook");
            Console.WriteLine("3. Calculate Average Grade");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent(gradeBook);
                    break;
                case "2":
                    ViewGradebook(gradeBook);
                    break;
                case "3":
                    CalculateAverage(gradeBook);
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Nice working with you! Have a nice day!");
                    break;

            }
        }
    }

    static void AddStudent(Dictionary<string, List<int>> gradeBook)
    {
        Console.Write("Please enter the student's name: ");
        string name = Console.ReadLine();

        if (!gradeBook.ContainsKey(name))
        {
            gradeBook[name] = new List<int>();
            //int adds a count of students, so if its zero when the gradebook is viewed it says "No students here"
        }

        Console.Write("Please enter grades separated by commas (e.g., 81, 98, 88): ");
        string[] gradesInput = Console.ReadLine().Split(',');

        foreach (string grade in gradesInput)
        {
            if (int.TryParse(grade.Trim(), out int gradeValue))

                gradeBook[name].Add(gradeValue);

            else
            {
                Console.WriteLine($"Invalid grade '{grade}'. Skipping...");
            }

        }

        Console.WriteLine($"Grades added for {name}.");

    }

        static void ViewGradebook(Dictionary<string, List<int>> gradeBook)
        {
        Console.WriteLine("/n--- Gradebook ---");
             Console.WriteLine("--Viewing Gradebook...--");
            foreach (var student in gradeBook)
            {
                
                Console.WriteLine($"Student: {student.Key}, Grades: {string.Join(", ", student.Value)}");

            }
           
            
            {
                Console.WriteLine("No students here");
            }
        }

        static void CalculateAverage(Dictionary<string, List<int>> gradeBook)
        {
            Console.Write("Enter student name to calculate average: ");
            string name = Console.ReadLine();

            if (gradeBook.ContainsKey(name))
            {
                List<int> grades = gradeBook[name];
                double average = grades.Count > 0 ? (double)grades.Sum() / grades.Count : 0;
                Console.WriteLine($"Average grade for {name}: {average:F2}");
            }
            else
            {
                Console.WriteLine($"Student '{name}' not found.");
            }
        }
    }


