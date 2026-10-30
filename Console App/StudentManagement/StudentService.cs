using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement;

    public class StudentService : IStudentService
    {
        private readonly List<Student> _students = new();

        public void Add(Student student)
        {
            if(_students.Any(s => s.Id == student.Id))
            {
                throw new ArgumentException("Id already exists");
            }
            _students.Add(student);
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
        return true;
    }
        
    }

