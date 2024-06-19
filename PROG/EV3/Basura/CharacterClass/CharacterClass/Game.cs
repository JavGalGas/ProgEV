using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterClass
{
    public delegate void Visit<T>(T element);
    public class Game
    {
        public Game() { }

        private Team _teamPlayer = new Team("Player Team");
        private Team _teamEnemy = new Team("Enemy Team");

        public void VisitTeams()
        {

        }
    }
}
