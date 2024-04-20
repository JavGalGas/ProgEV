using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public delegate void VisitCharacterDelegate<T>(Character character);
    public class Match
    {
        private IField _field = new FieldBasedOnList();
        private List<Character> _characterList = new List<Character>();
        private Team _teamA = new Team("A");
        private Team _teamB = new Team("B");  
        private string _winner = "";//guardar o no ??????????


        private void GenerateCharacters()//revisar
        {   
            for (int y = 0; y <= 19; y+= 19)
            {
                Team team;
                if (y == 0)
                    team = _teamA;
                else
                    team = _teamB;

                for (int x = 3; x < 7; x++)
                {
                    _characterList.Add(new Defender("defender" + x, team, x, y));
                }
            }
            for (int y = 1; y <= 18; y += 18)
            {
                Team team;
                if (y == 1)
                    team = _teamA;
                else
                    team = _teamB;

                for (int x = 3; x < 7; x++)
                {
                    _characterList.Add(new Striker("striker" + x, team, x, y));
                }
            }
            for (int y = 0; y <= 19; y += 19)
            {
                Team team;
                if (y == 0)
                    team = _teamA;
                else
                    team = _teamB;

                for (int x = 2; x < 8; x+=5)
                {
                    _characterList.Add(new SpecialDefender("sp_defender" + x, team, x, y));
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

        private bool HasScore(Character ch, ref Team? GoalTeam, ref int points)
        {
            GoalTeam = null;
            if (ch.GetCharacterType() == CharacterType.STRIKER)
            {
                Striker newCh = (Striker)ch;
                HasScoreInternalCheck(newCh, ref points, ref GoalTeam);
            }
            if (ch.GetCharacterType() == CharacterType.DEFENDER)
            {
                Defender newCh = (Defender)ch;
                HasScoreInternalCheck(newCh, ref points, ref GoalTeam);
            }
            if (ch.GetCharacterType() == CharacterType.SP_DEFENDER)
            {
                SpecialDefender newCh = (SpecialDefender)ch;
                HasScoreInternalCheck(newCh, ref points, ref GoalTeam);
            }
            return false;
        }

        private bool HasScoreInternalCheck(Player newCh, ref int points, ref Team? GoalTeam)
        {
            if (newCh.HasBall)
            {
                points = 3;
                if (newCh.GetCharacterType() == CharacterType.STRIKER)
                    points = 10;
                if (newCh.Position.Y == 19 && newCh.Team == _teamA)
                {
                    GoalTeam = _teamA;
                    return true;
                }
                if (newCh.Position.Y == 0 && newCh.Team == _teamB)
                {
                    GoalTeam = _teamB;
                    return true;
                }
                return false;
            }
            return false;
        }

        public void Start()
        {
            GenerateCharacters();
            _field.SetBall();
            AddCharactersToField();
        }
        public void Execute()
        {
            Team? goalTeam = null;
            int points = 0;
            
            for (int round = 0; round < 1000; round++)
            {
                VisitCharacters(character =>
                {
                    character.ExecuteTurn(_field);
                });
                foreach (var charac in _characterList)
                {
                    if(HasScore(charac, ref goalTeam, ref points))
                    {
                        goalTeam!.SetPoints(points);
                        //if(goalTeam == _teamA)
                        //{
                        //    _teamA.SetPoints(points);
                        //}
                        //if (goalTeam == _teamB)
                        //{
                        //    _teamB.SetPoints(points);

                        //}

                        //sumar gol al equipo correspondiente
                        //reiniciar posicion jugadores
                        _field = new FieldBasedOnList();
                        Start();
                        break;
                    }
                }
            }
            SetWinner(ref _winner);
            Console.WriteLine(_winner);
        }

        private void SetWinner(ref string _winner)
        {
            _winner = "The winner is : ";
            if(_teamA.Points < _teamB.Points)
                _winner+= "Team A";
            else if(_teamA.Points > _teamB.Points)
                _winner = "Team B";
            else
            {
                _winner = "Draw";
            }
            
        }

        public void VisitCharacters(VisitCharacterDelegate<Character> visitor)
        {
            if (visitor == null)
                return;
            foreach (var character in _characterList)
                visitor(character);
        }

    }
}
