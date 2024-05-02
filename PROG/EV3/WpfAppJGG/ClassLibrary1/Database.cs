using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppJGG
{
    public class Database : IDatabase
    {
        public List<Student> Students;
        public long AddStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(long id)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentAt(int index)
        {
            throw new NotImplementedException();
        }

        public int GetStudentCount()
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(long id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(long id, Student student)
        {
            throw new NotImplementedException();
        }
    }
}
