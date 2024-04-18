using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public enum TeamType
    {
        RED,
        BLUE
    }
    public class Team
    {
        private string _name;
        public Player[] team = new Player[10];
        private int _points = 0;
        public TeamType type;

        public Team(string name, TeamType type)
        {
            _name = name;
            this.type = type;
        }
        public void AddPoints(int points)
        {
            _points+= points;
        }

        public void AddPlayer(Player player)
        {
            if (player == null)
                return;
            player.SetTeam(this);
            for(int i = 0; i < team.Length; i++)
            {
                if (team[i] == null)
                    team[i] = player;
            }
        }
    }
}
