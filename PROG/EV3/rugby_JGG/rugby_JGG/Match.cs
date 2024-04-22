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

        private void RestartPosition(Team team)
        {
            var list = GetCharactersFromATeam(team);
            int sp_defenderIndex = 3;
            int defenderIndex = 3;
            int strikerIndex = 3;
            foreach (var player in list)
            {
                if (player is SpecialDefender sd)
                {
                    Utils.ConfigureSpecialDefender(sd, sp_defenderIndex++);
                }
                if (player is Defender d)
                {
                    Utils.ConfigureDefender(d,defenderIndex++);
                }
                if (player is Striker s)
                {
                    Utils.ConfigureStriker(s, strikerIndex++);
                }
            }
        }

        private void RestartPosition()
        {
            RestartPosition(_teamA);
            RestartPosition(_teamB);
        }

        private List<Character> GetCharactersFromATeam(Team team)
        {
            var ret = new List<Character>();
            foreach(var character in _characterList)
                if (character is Player p && p.Team == team)
                    ret.Add(character);

            return ret;
        }

        private Player? GetScorePlayer()
        {
            Ball b = _field.GetBall();
            foreach (var character in _characterList)
            {
                if (character is Player jugador)
                    if (jugador.HasScore(b))
                        return jugador;
            }
            return null;
        }

        private bool IsGoal()
        {
            return GetScorePlayer() != null;
        }

        private void SetPointsToTeam()
        {
            Player? player = GetScorePlayer();
            if (player == null)
                return;
            if (player is SpecialDefender)
                player.Team.SetPoints(1);
            else if (player is Defender)
                player.Team.SetPoints(3);
            else if (player is Striker)
                player.Team.SetPoints(10);
            else
                player.Team.SetPoints(0);
        }

        public void Start()
        {
            GenerateCharacters();
            _field.SetBall();
            AddCharactersToField();
        }
        public void Execute()
        {            
            for (int round = 0; round < 1000; round++)
            {
                VisitCharacters(character =>
                {
                    character.ExecuteTurn(_field);
                });
                foreach (var charac in _characterList)
                {
                    if(IsGoal())
                    {
                        SetPointsToTeam();
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
