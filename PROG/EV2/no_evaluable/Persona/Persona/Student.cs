using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    public class Student : Person
    {
        public long nia;

        public Student(long nia)
        {
            this.nia = nia;
        }
        public Student(string name, long nia) : base(name, Gender.OTHER)
        {
            this.nia = nia;
        }

        public override string GetFullName()
        {
            return "<STUDENT>" + Name + "</STUDENT>";
        }

        public override void ExecuteTurn()
        {
            
        }


    }
}
