using System.Security.Cryptography.X509Certificates;

namespace Persona
{
    internal class Program
    {
        public static Person? CreatePerson()
        {/*
            return new Person()
            {
                Name = "Juan",
                Gender = Gender.MALE
            };*/
            return null;
        }
        public static Person? CreatePerson2()
        {/*
            return new Person()
            {
                Name = "Pablo",
                Gender = Gender.MALE
            };*/
            return null;
        }

        static void Main(string[] args)
        {
            //Person p = new Person();
            //Person pp=new Person("Pepe", Gender.MALE);
            Teacher teacher = new Teacher(1.0);
            Teacher t1 = new Teacher()
            {
                Name= "Juan",
                Gender = Gender.MALE,
            };

            Graveyard yard= new Graveyard();

            //Person apipapacayo = CreatePerson();
            //string name = apipapacayo.GetFullName();
            //Console.WriteLine(name);
            //IPerro p = new Teacher();







        }
    }
}