using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement
{
    public class Student
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public int Marks { get; private set; }

      public Student(string id, string name, int marks)
      {
           
            Id = id;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Name cannot be empty");
            Name = name;

            if (marks < 0 || marks > 100)
                throw new ArgumentException("Marks must be betweeen 0 and 100");
            Marks = marks;
       }

        public string Grade => Marks >= 80 ? "A+" :
                               Marks >= 70 ? "A" :
                               Marks >= 60 ? "A-" :
                               Marks >= 50 ? "B" :
                               Marks >= 40 ? "C" :
                               Marks >= 33 ? "D" : "F";

        public void UpdateMarks(int newMarks)
        {
            if (newMarks < 0 || newMarks > 100)
                throw new ArgumentException("Marks must be between 0 to 100");
            Marks = newMarks;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id} | Name : {Name} | Marks: {Marks} | Grade: {Grade}");
        }
    }
}
