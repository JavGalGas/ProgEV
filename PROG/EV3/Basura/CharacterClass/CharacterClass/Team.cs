using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClass
{
    public class Team
    {
        private string _name = string.Empty;
        public string Name => _name;
        private List<Character> _team = new List<Character>();
        private HealthItem[] _items = new HealthItem[10];
        private int _itemCount = 0;
        
        public Team(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            _name = name;
        }

        public void AddCharacter(Character character)
        {
            if (character == null)
                throw new ArgumentNullException(nameof(character));
            if (_team.Count >= 5 || ContainsCharacterWithId(character.Id))
                throw new ArgumentOutOfRangeException(nameof(character));
            _team.Add(character);
        }

        public void AddHealthItem(HealthItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (_itemCount >= _items.Length || ContainsItemWithId(item.Id))
                throw new ArgumentOutOfRangeException(nameof(item));
            _items[_itemCount] = item;
        }

        public void RemoveCharacter(Character character)
        {
            if (character == null)
                throw new ArgumentNullException(nameof(character));
            _team.Remove(character);
        }

        public void RemoveHealthItem(HealthItem item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            int removedItem = IndexOfHealthItem(item);
            HealthItem[] newArray = new HealthItem[10];
            for (int i = 0; i < removedItem; i++)
            {
                newArray[i] = _items[i];
            }
            for (int i = removedItem; i < newArray.Length; i++)
            {
                newArray[i] = _items[i + 1];
            }
        }

        public void RemoveCharacterByPosition(int index)
        {
            if (index < 0 || index >=5)
                throw new ArgumentOutOfRangeException(nameof(index));
            _team.RemoveAt(index);
        }

        public Character GetCharacterAt(int index)
        {
            if (index < 0 || index >= 5)
                throw new ArgumentOutOfRangeException(nameof(index));
            return _team[index];
        }

        public void UpdateCharacter(int index, Character character)
        {
            if (character == null)
                throw new ArgumentNullException(nameof(character));
            if (index < 0 || index >= 5)
                throw new ArgumentOutOfRangeException(nameof(index));
            _team[index] = character;
        }

        public bool ContainsCharacterWithId(long id)
        {
            foreach (var character in _team)
                if (character.Id == id)
                    return true;
            return false;
        }

        public bool ContainsItemWithId(long id)
        {
            foreach (var item in _items)
                if (item.Id == id)
                    return true;
            return false;
        }

        public int IndexOfCharacter(Character character)
        {
            if (_team == null || character == null)
                return -1;
            for (int i= 0; i< _team.Count; i++)
            {
                if (_team[i].Equals(character))
                    return i;
            }
               
            return -1;
        }

        public int IndexOfHealthItem(HealthItem item)
        {
            if (_items == null || item == null)
                return -1;
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                    return i;
            }

            return -1;
        }
    }
}
