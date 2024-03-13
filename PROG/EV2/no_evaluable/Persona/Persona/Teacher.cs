using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    public class Teacher : Person, IPerro
    {
        public double bloodLust;


        public Teacher()
        {

        }
        public Teacher(double bloodLust)
        {
            //bloodLust = Random(); los datos deben de mantenerse
            this.bloodLust = bloodLust;
        }
        public Teacher(string name, double bloodLust)
            :base(name, Gender.OTHER)
        {
            this.bloodLust=bloodLust;
        }

        public override string GetFullName()
        {
            return "<PROFESOR>" + Name + "</PROFESOR>";//Tambien base.GetFullName()
        }

        public override void ExecuteTurn()
        {

        }

        void IPerro.Metodo1()
        {
            throw new NotImplementedException();
        }

        void IPerro.Metodo2()
        {
            throw new NotImplementedException();
        }

        void IPerro.Metodo3()
        {
            throw new NotImplementedException();
        }

        void ICosa.Metodo()
        {
            throw new NotImplementedException();
        }
    }
}
