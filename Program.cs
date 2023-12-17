
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public string Class { get; set; }
}

class Program
{
    static void Main()
    {
        List<Student> students = ReadStudentData(@"C:\Users\LENOVO\Documents\project3\student.txt");

        Console.WriteLine("Student Data (Unsorted):");
        DisplayStudentData(students);

        SortStudentsByName(students);

        Console.WriteLine("\nStudent Data (Sorted by Name):");
        DisplayStudentData(students);

        Console.Write("\nEnter student name to search: ");
        string searchName = Console.ReadLine();
        SearchStudentByName(students, searchName);
    }

    static List<Student> ReadStudentData(string filePath)
    {
        List<Student> students = new List<Student>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] data = line.Split(',');
                students.Add(new Student { Name = data[0].Trim(), Class = data[1].Trim() });
            }
        }

        return students;
    }

    static void SortStudentsByName(List<Student> students)
    {
        students.Sort((s1, s2) => string.Compare(s1.Name, s2.Name, StringComparison.Ordinal));
    }

    static void DisplayStudentData(List<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
        }
    }

    static void SearchStudentByName(List<Student> students, string searchName)
    {
        Student foundStudent = students.Find(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

        if (foundStudent != null)
        {
            Console.WriteLine($"Student found - Name: {foundStudent.Name}, Class: {foundStudent.Class}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }
}