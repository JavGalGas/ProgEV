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
        private (int, int) _matchArea = (10, 20);
        private Ball? ball;
        public List<Character> characterList = new List<Character>();
        private string _winner = "";

        public int MatchX => _matchArea.Item1;
        public int MatchY => _matchArea.Item2;

        public void Start()
        {
            ball = new Ball();
            VisitCharacters(characters =>
            {
                if (characters.GetType() == typeof(Player))
                {
                    var type = characters.GetType();
                    characters.SetPosition((0, 0));
                }
                if (characters.GetType() == typeof(Dementor))
                {
                    characters.SetPosition(SetRandomPosition());
                }
            });//revisar las posiciones de los personajes
        }
        public void Execute()
        {
            bool goal = false;
            if (ball == null)
                return;
            for (int i = 0; i < 1000; i++)
            {
                if (i == 0 || goal/*Han marcado gol o comienza el partido*/)
                {
                    ball.SetPosition(SetRandomPosition());

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
                VisitCharacters(character =>
                {
                    characterList[i].ExecuteTurn(this);
                });
                    /*...*/
            }
        }

        public void VisitCharacters(VisitCharacterDelegate<Character> visit)
        {
            if (visit == null)
                return;
            foreach (var character in characterList)
                visit(character);
        }

        private (int,int) SetRandomPosition()
        {
            int x = Utils.GetRandomBetween(0, MatchX);
            int y = Utils.GetRandomBetween(0, MatchY);
            return (x, y);
        }
    }
}
