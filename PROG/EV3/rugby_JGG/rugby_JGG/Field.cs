using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public interface IField
    {
        const int WIDTH = 10;
        const int HEIGHT = 20;
        bool IsAvailable(int x, int y);
        void AddCharacter(Character character);
        Character? GetCharacterAt(int x, int y);
        Ball GetBall();
        List<Position> GetAvailableSpaces();
        bool IsAvailable(Position position)
        {
            return position==null ? false : IsAvailable(position.X,position.Y);
        }
    }

    public class FieldBasadoEnArray : IField
    {
        private Ball _ball = new(new Position());
        private List<Character> _characters = new List<Character>();
        public void AddCharacter(Character character)
        {
            if (character==null) 
                throw new Exception("Character is null.");
            if (!((IField)this).IsAvailable(character.position!))
                throw new Exception("Character with invalid position");
            if (Contains(character))
                throw new Exception("The character already exists");
            _characters.Add(character);
        }

        public bool Contains(Character character)
        {
            return IndexOf(character) >= 0;
        }

        private int IndexOf(Character character)
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                if (_characters[i]==character) 
                    return i;
            }
            return -1;
        }

        public Ball GetBall()
        {
            throw new NotImplementedException();
        }

        public Character? GetCharacterAt(int x, int y)
        {
            foreach (var p in _characters)
                if (p.position.X == x && p.position.Y == y)
                    return p;
            return null;
        }
        
        public List<Position> GetAvailableSpaces()
        {
            List<Position> result = new();
            for (int x = 0; x < IField.WIDTH; x++)
            {
                for (int y = 0; y < IField.HEIGHT; y++)
                {
                    if (IsAvailable(x, y))
                        result.Add(new Position(x, y));
                }
            }
            return result;
        }

        public bool IsAvailable(int x, int y)
        {
            if (x < 0 || x >= 10)
                return false;
            if (y < 0 || y >= 20)
                return false;
            return GetCharacterAt(x, y) == null;
        }
    }

    //public class FieldBasadoEnListaDeCosas : IField
    //{
    //    public void AddCharacter(Character character)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Ball GetBall()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Character? GetCharacterAt(int x, int y)
    //    {
            
    //    }

    //    public bool IsAvailable(int x, int y)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
