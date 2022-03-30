using System;
using System.Collections.Generic;
using System.Text.Json;

namespace PracticeStudentsSerialization
{
    class Program
    {
        const string nameFile = "students.json";
        const int fee = 10000;
        const int discount = 10;
        const int underAge = 25;
        static void Main(string[] args)
        {
            List<Student> students = Deserialize();
            string? choice = null;

            do
            {
                Out.printMenu();
                choice = Console.ReadLine().ToLower();
                switch (choice)
                {
                    case "a":
                        Add(students);
                        break;
                    case "r":
                        Remove(students);
                        break;
                    case "p":
                        Print(students);
                        break;
                    case "fr":
                        FeeReport(students);
                        break;
                    default:
                        break;
                }
            } while (choice != "q");

        }
        static List<Student> Deserialize()
        {
            string jsonString = "";
            try
            {
                jsonString = File.ReadAllText(nameFile);
            }
            catch (Exception ex)
            {
                File.WriteAllText(nameFile, "");
                return new List<Student>();
            }
            List<Student>? students = JsonSerializer.Deserialize<List<Student>>(jsonString);
            return students;
        }
        static void Serialize(List<Student> students)
        {
            string jsonString = JsonSerializer.Serialize(students);
            File.WriteAllText(nameFile, jsonString);
        }
        static void Add(List<Student> students)
        {
            Console.WriteLine("Enter student id :");
            string? id = Console.ReadLine();
            foreach (var student in students)
                if (student.Id == id)
                {
                    Console.WriteLine($"Cannot add {student.Name}");
                    Add(students);
                    return;
                }
            Console.WriteLine("Enter student name :");
            string? name = Console.ReadLine();
            Console.WriteLine("Enter student age :");
            int age = int.Parse(Console.ReadLine());
            Student newStudent = new Student(id, name, age);
            students.Add(newStudent);
            Serialize(students);
        }

        static void Remove(List<Student> students)
        {
            Console.WriteLine("Enter id to remove :");
            string? id = Console.ReadLine();
            foreach (var student in students)
                if (student.Id == id)
                {
                    students.Remove(student);
                    break;
                }
            Serialize(students);
        }
        static void Print(List<Student> students)
        {

            Console.WriteLine("Id,Name,Age");
            foreach (var student in students)
                Console.WriteLine(student.ToString());
        }
        static void Contains(List<Student> students)
        {
            Console.WriteLine("Enter text contans :");
            string? str = Console.ReadLine();
            //Console.WriteLine(students.Contains(str));
        }

        static void FeeReport(List<Student> students)
        {
            foreach (var student in students)
            {
                var FinalFee = student.Age < underAge ? fee / 100 * (100 - discount) : fee;
                Console.WriteLine($"{student} need to pay {FinalFee}");
            }
        }

    }
}
