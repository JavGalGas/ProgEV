

namespace Persona
{
    public enum Gender
    {
        MALE,
        FEMALE,
        OTHER,
    }
    public abstract class Person
    {
        private string _name = "";
        private Gender _gender;
        public int[] array;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }//Nuevo constructor "Properties"
        public Person(): this("", Gender.OTHER)
        {

            //_name = "";
            //_gender = Gender.OTHER;
        }
        public Person(string name, Gender gender)
        {
            this._name = name;
            this._gender = gender;
            this.array = new int[10];
            for(int i = 0; i < array.Length; i++)
                this.array[i] = i;
        }

        public virtual string GetFullName()
        {
            return this._name;
        }

        public abstract void ExecuteTurn();
    }
}
