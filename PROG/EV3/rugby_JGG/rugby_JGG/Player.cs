using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public abstract class Player : Character
    {
        protected Position _initPosition;
        private string _name;
        private Team? _team;
        private bool _hasBall;

        public string Name => _name;
        public int Init_X => _initPosition.X;
        public int Init_Y => _initPosition.Y;
        public bool HasBall => _hasBall;
        public Team? Team => _team;

        public Player(string name, Team team, Position position) : base(position)
        {      
            _name = name;
            _team = team;
            _initPosition = position;
        }

        //public virtual void SetInitPosition()
        //{
        //    _initPosition = ;
        //}
    }
}
