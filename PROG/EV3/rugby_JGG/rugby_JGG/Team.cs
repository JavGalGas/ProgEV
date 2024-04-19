using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    /*public enum TeamType
    {
        RED,
        BLUE
    }*/
    public delegate void VisitTeamDelegate<T>(Player player);
    public class Team
    {
        private string _name;
        private Player[] _team = new Player[10];
        private int _points = 0;
        /*public TeamType type;*/

        public Team(string name/*, TeamType type*/)
        {
            _name = name;
            /*this.type = type;*/

        }
        public void SetPoints(int points)
        {
            _points = points;
        }

        public void AddPlayer(Player player)
        {
            if (player == null)
                return;

            int numStrikers = 0;
            int numDefenders = 0;
            int numSpecialDefenders = 0;

            VisitTeam(teamPlayer =>
            {
                if(teamPlayer == null) 
                    return;
                if (teamPlayer.GetType() == typeof(Striker))
                    numStrikers++;
                if (teamPlayer.GetType() == typeof(Defender))
                    numDefenders++;
                if (teamPlayer.GetType() == typeof(SpecialDefender))
                    numSpecialDefenders++;
            });
            if (player.GetType() == typeof(Striker))
                numStrikers++;
            if (player.GetType() == typeof(Defender))
                numDefenders++;
            if (player.GetType() == typeof(SpecialDefender))
                numSpecialDefenders++;
            if (numStrikers <= 4 && numDefenders <= 4 && numSpecialDefenders <=2) 
            {
                player.SetTeam(this);
                for (int i = 0; i < _team.Length; i++)
                {
                    if (_team[i] == null)
                        _team[i] = player;
                }
            }
        }

        public void VisitTeam(VisitTeamDelegate<Player> visit)
        {
            if(visit == null)
                return;
            foreach (Player player in _team)
            {
                visit(player);
            }
        }

        public Player[] GetTeamPlayers()
        {
            Player[] dupTeam = new Player[_team.Length];
            for (int i = 0; i< _team.Length; i++ )
                dupTeam[i] = _team[i];
            return dupTeam;
        }
    }
}
