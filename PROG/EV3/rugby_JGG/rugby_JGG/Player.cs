using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Player : Character
    {
        private int _initX;
        private int _initY;
        private Team? _team;
        public bool hasBall;//seguir

        public Player(int x, int y) : base(x, y)
        {      
            
        }

        public override void ExecuteTurn()
        {
            throw new NotImplementedException();
        }

        public void SetTeam(Team team)
        {
            _team = team;
        }
    }
}
