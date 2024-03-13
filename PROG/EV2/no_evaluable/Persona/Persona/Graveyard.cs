using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persona
{
    public class Graveyard
    {
        private List<Person> _personList = new List<Person>();


        public int GetPersonCount()
        {
            return _personList.Count;
        }
        public int PersonCount => GetPersonCount();
        public Person this[int index] => _personList[index];
        public void AddPerson(Person p)
        {
            if(p == null)
                return;
            _personList.Add(p);
        }
        public void RemovePersonAt(int index)
        {
            if(index < 0 || index >= _personList.Count)
                return;
            _personList.RemoveAt(index);
        }

        public void ExecuteFrame()
        {
            for(int i=0; i< _personList.Count; i++)
            {
                Person p = _personList[i];
                p.ExecuteTurn();
            }
        }

    }
}
