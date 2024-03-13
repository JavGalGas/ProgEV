using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    public class Director :Teacher
    {
        public override string GetFullName()
        {
            return "<DIRECTOR>" + Name + "</DIRECTOR>";
        }

        public override void ExecuteTurn()
        {
            base.ExecuteTurn();
        }





    }
}
