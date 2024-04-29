using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppJGG
{
    public interface IDatabase
    {
        long AddStudent(Student student);
        Student GetStudent(long id);
        void UpdateStudent(long id, Student student);
        void RemoveStudent(long id);
        Student GetStudentAt(int index);
        int GetStudentCount();
    }
}
