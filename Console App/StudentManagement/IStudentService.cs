using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement;

    public interface IStudentService
    {
        void Add(Student student);
        List<Student> GetAll();
        List<Student> SearchByName (string name);
        bool UpdateMarks(string id, int newMarks);
        bool DeleteStudent(string id);
    }

