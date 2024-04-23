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

        void SetBall();
        List<Position> GetAvailableSpaces();
        bool IsAvailable(Position position)
        {
            return position==null ? false : IsAvailable(position.X,position.Y);
        }
        Character? GetCharacterAt(Position position)
        {
            return GetCharacterAt(position.X,position.Y);
        }
    }

    public class FieldBasedOnList : IField
    {
        private Ball _ball = new(new Position());
        private List<Character> _characters = new List<Character>();
        public void AddCharacter(Character character)
        {
            if (character==null) 
                throw new Exception("Character is null.");
            if (!((IField)this).IsAvailable(character.Position!))
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
            return _ball;
        }

        public void SetBall()
        {
            List <Position> list = GetAvailableSpaces2();
            var index = Utils.GetRandomBetween(0, list.Count - 1);
            var positions = list[index];
            _ball.SetPosition(positions);
        }

        public List<Position> GetAvailableSpaces2()
        {
            List<Position> result = new();
            for (int x = 0; x < IField.WIDTH; x++)
            {
                for (int y = 0; y < IField.HEIGHT; y++)
                {
                    if (IsAvailable(x, y))
                        result.Add(new Position(x, y));
                    Character? character = GetCharacterAt(x, y);
                    if(character != null)
                    {
                        if (character.GetCharacterType() == CharacterType.DEMENTOR)
                            continue;
                        result.Add(new Position(x, y));
                    }
                }
            }
            return result;
        }

        public Character? GetCharacterAt(int x, int y)
        {
            foreach (var p in _characters)
                if (p.Position.X == x && p.Position.Y == y)
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
            if (x < 0 || x >= IField.WIDTH)
                return false;
            if (y < 0 || y >= IField.HEIGHT)
                return false;
            return GetCharacterAt(x, y) == null;
        }

        
    }

    //public class FieldBasedOnArray : IField
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
