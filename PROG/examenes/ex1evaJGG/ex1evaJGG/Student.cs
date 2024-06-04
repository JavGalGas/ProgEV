using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex1evaJGG
{
    public enum Gender
    {
        MASCULINE,
        FEMININE,
        OTHER
    }
    public class Student
    {
        private string _name = string.Empty;
        private int _age;
        private Gender _gender;
        private int _height;
        private int _weight;
        private Notes _notes = new Notes();

        public Student()
        {

        }

        public Student(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public void SetName(string name)
        {
            if (_name == null)
                return;
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetAge(int age)
        {
            if (age <= 0 || age > 100)
                return;
            _age = age;
        }

        public int GetAge() 
        { 
            return _age;
        }

        public double GetIMC()
        {
            return Convert.ToDouble(_weight / (_height * _height));
        }

        public double GetStudentAverageNote()
        {
            if (_notes == null)
                return double.MinValue;
            return _notes.GetAverageNote();
        }

        public bool IsAnAdult()
        {
            return _age >= 18;
        }

        public Student Clone()//modificar
        {
            Student student = new Student();
            student._name = _name;
            student._age = _age;
            student._gender = _gender;
            student._weight = _weight;
            student._height = _height;
            Notes notes = new Notes();


            return student;
        }
    }
}
