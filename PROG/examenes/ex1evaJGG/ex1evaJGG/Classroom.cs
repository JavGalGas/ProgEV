using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ex1evaJGG
{
    public class Classroom
    {
        private List<Student> _students = new List<Student>();
        private string _name = string.Empty;

        public Classroom()
        {

        }

        public Classroom(List<Student> students, string name)
        {
            _students = students;
            _name = name;
        }

        public void SetName(string name)
        {
            if (name == null)
                return;
            _name = name;
        }

        public string GetName() 
        { 
            return _name; 
        }

        public void SetStudents(List<Student> students)
        {
            if (students == null)
                return;
            _students = new List<Student>(students.Count);
            foreach (Student student in students)
            {
                if (student != null)
                {
                    _students.Add(student);
                }
            }
        }

        public List<Student> GetStudents() 
        {
            return _students;
        }

        public void AddStudent(Student student)
        {
            if (student == null) 
                return;
            foreach (Student listStudent in _students)
            {
                if (student.Equals(listStudent))
                    return;
            }
            _students.Add(student);   
        }

        public void RemoveStudentAt(int index)
        {
            //_students.RemoveAt(index);
            _students.Remove(_students[index]);
        }

        public bool ContainsStudentWithName(string name)
        {
            foreach (Student student in _students)
            {
                if (student.GetName() ==name )
                    return true;
            }
            return false;
        }

        public void RemoveStudentsWithName(string name)
        {
            for (int i=0; i < _students.Count; i++)
            {
                if (_students[i].GetName() ==name)
                {
                    //RemoveStudentAt(i);
                    _students.Remove(_students[i]);
                    i--;
                }
            }
        }
    }
}
