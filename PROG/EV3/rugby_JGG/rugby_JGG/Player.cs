using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public abstract class Player : Character
    {
        protected (int, int) _initPosition;
        private string _name;
        private Team? _team;
        private bool _hasBall;

        public string Name => _name;
        public int Init_X => _initPosition.Item1;
        public int Init_Y => _initPosition.Item2;
        public bool HasBall => _hasBall;
        public Team? Team => _team;

        public Player(string name)
        {      
            _name = name;
        }

        public void SetTeam(Team team)
        {
            _team = team;
        }

        public virtual void SetInitPosition()
        {
            _initPosition = (_x,_y);
        }
    }
}
