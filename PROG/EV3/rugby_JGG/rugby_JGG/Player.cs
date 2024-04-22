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
        private Team _team;
        protected bool _hasBall;

        public string Name => _name;
        public int Init_X => _initPosition.X;
        public int Init_Y => _initPosition.Y;
        public bool HasBall => _hasBall;
        public Team Team => _team;

        public TeamDirection teamDirection => _team.teamDirection;

        public Player(string name, Team team, Position position) : base(position)
        {      
            _name = name;
            _team = team;
            _initPosition = position;
        }

        public bool HasScore(Ball ball)
        {
            bool hasBall = ball.HasBallPlayer == this;

            if (hasBall)
            {
                if (_team.teamDirection == TeamDirection.HACIA_ARRIBA)
                    return Position.Y == 0;
                else
                    return Position.Y == IField.HEIGHT - 1;
            }
            return false;
        }

    }
}
