using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClass
{
    public class Team
    {
        private string _name = string.Empty;
        public string Name => _name;
        private List<Character> _team = new List<Character>();
        
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
            if (_team.Count >= 5)
                throw new ArgumentOutOfRangeException(nameof(character));
            _team.Add(character);
        }

        public void RemoveCharacter(Character character)
        {
            if (character == null)
                throw new ArgumentNullException(nameof(character));
            _team.Remove(character);
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
    }
}
