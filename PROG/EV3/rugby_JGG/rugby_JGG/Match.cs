using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public delegate void VisitCharacterDelegate<T>(Character character);
    public class Match
    {
        private IField _field = new FieldBasadoEnArray();
        private List<Character> _characterList = new List<Character>();
        private Team _teamA = new Team("A");
        private Team _teamB = new Team("B");


        private (int, int) _matchArea = (10, 20);
        private Ball? ball;
        
        private string _winner = "";

        public int MatchX => _matchArea.Item1;
        public int MatchY => _matchArea.Item2;

        private void GenerateCharacters()//revisar
        {
            _characterList.Add(new SpecialDefender("a", _teamA, 3, 1));
            for (int y = 0; y <= 19; y+= 19)
            {
                for (int x = 4; x < 8; x++)
                {
                    _characterList.Add(new SpecialDefender("a", _teamA, 3, 1));
                }
            }
            


            var list = _field.GetAvailableSpaces();
            for (int i= 0; i < 4; i++)
            {
                var index = Utils.GetRandomBetween(0, list.Count - 1);
                var positions = list[index];
                var dementor = new Dementor(positions);
                _field.AddCharacter(dementor);
                list.RemoveAt(index);
            }

        }
        private void AddCharactersToField()
        {
            VisitCharacters(ch =>_field.AddCharacter(ch));
        }

        

        public void Start()
        {
            GenerateCharacters();
            AddCharactersToField();
        }
        public void Execute()
        {
            bool goal = false;
            if (ball == null)
                return;
            for (int round = 0; round < 1000; round++)
            {
                VisitCharacters(character =>
                {
                    _characterList[round].ExecuteTurn(_field);
                });
                if (goal/*Han marcado gol o comienza el partido*/)
                {
                    //sumar gol al equipo correspondiente
                    //reiniciar posicion jugadores

                    VisitCharacters(characters =>
                    {
                        if (characters.GetType() == typeof(Striker) || characters.GetType() == typeof(Defender) || characters.GetType() == typeof(SpecialDefender))
                        {
                            characters.SetPosition((0, 0));
                        }
                        if (characters.GetType() == typeof(Dementor)) 
                        {
                            characters.SetPosition(SetRandomPosition());
                        }
                    });
                    goal = false;
                }
                
                    /*...*/
            }
        }

        public void VisitCharacters(VisitCharacterDelegate<Character> visitor)
        {
            if (visitor == null)
                return;
            foreach (var character in _characterList)
                visitor(character);
        }

        private (int,int) SetRandomPosition()
        {
            int x = Utils.GetRandomBetween(0, MatchX);
            int y = Utils.GetRandomBetween(0, MatchY);
            return (x, y);
        }
    }
}
