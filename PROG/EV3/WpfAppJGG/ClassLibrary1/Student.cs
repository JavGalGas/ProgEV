using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppJGG
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Description { get; set; } = string.Empty;

        public Student()
        {

        }
        public Student(int id, string name, int age, string description)
        {
            Id = id;
            Name = name;
            Age = age;
            Description = description;
        }
    }
}
