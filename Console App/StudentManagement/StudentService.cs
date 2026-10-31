using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace StudentManagement;

    public class StudentService : IStudentService
    {
       
        private readonly List<Student> _students = new();
        private const string FilePath = "students.json";
        
       public StudentService() { Load(); }

    public void Add(Student student)
        {
            if(_students.Any(s => s.Id == student.Id))
            {
                throw new ArgumentException("Id already exists");
            }
            _students.Add(student);
            Save();
        }

        public List<Student> GetAll()
        {
          return _students.ToList();
         
        }

        public List<Student> SearchByName(string name)
        {
           return  _students.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                                  .ToList();

          
        }

        public bool UpdateMarks(string id,int newMarks)
        {
           var foundStudent = _students.FirstOrDefault(s => s.Id == id);
            if(foundStudent == null)
            {
                return false;
            }
            foundStudent.UpdateMarks(newMarks);
            Save();
            return true;
             

    }

     public bool DeleteStudent(string id)
      {
        var deleteStudent = _students.FirstOrDefault(s => s.Id == id);
        if(deleteStudent == null)
        {
            return false;
        }
         _students.Remove(deleteStudent);
        Save();
        return true;
      
    }
       
     public List<Student> GetTopStudents(int count)
    {
       return _students.OrderByDescending(s => s.Marks)
                                   .Take(count)
                                   .ToList();
    }

    public double GetAverage()
    {
        if(_students.Count == 0)
            return 0;

        return _students.Average(s =>  s.Marks);
    }

    public Dictionary<string,int> GetGradeReport()
    {
        return _students.GroupBy(s => s.Grade)
                        .ToDictionary(g => g.Key, g => g.Count());
    }
    private void Save()
    {
        string json = JsonSerializer.Serialize(_students);
        File.WriteAllText(FilePath, json);
       
    }

    private void Load()
    {
        
        if (!File.Exists(FilePath))
        {
            return;
        }

        string text = File.ReadAllText(FilePath);

        var loaded = JsonSerializer.Deserialize<List<Student>>(text) ?? new List<Student>();
        _students.AddRange(loaded);
        
    }
    

    }

