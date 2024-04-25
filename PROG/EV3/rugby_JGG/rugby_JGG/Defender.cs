using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Defender : Player
    {
        protected double _abilityToStealBall;
        public Defender(string name, Team team, Position position, double abilityToStealBall) : base(name, team, position)
        {
            _abilityToStealBall = abilityToStealBall;
            if (abilityToStealBall < 0.4)
                _abilityToStealBall = 0.4;
            if (abilityToStealBall > 0.6)
                _abilityToStealBall = 0.6;

        }

        public Defender(string name, Team team, int x, int y, double abilityToStealBall) : this(name, team, new Position(x, y), abilityToStealBall)
        {
        }

        private void ExecuteTurnWithoutBall(IField field)
        {
            //bool tengolaPelota = IHaveTheBall(field);
            var ball = field.GetBall();
            bool ballAtReach = Utils.IsBallAtReach(this, field);
            bool ballWithoutOwner = ball.HasBallPlayer == null;
            if (ballAtReach)
            {
                if (ballWithoutOwner)
                {
                    ball.HasBallPlayer = this;
                }
                else if(Utils.ActivateWithProbability(_abilityToStealBall) && ball!.HasBallPlayer!.Team != Team)
                {
                    GoForAnOpponentPlayer();
                }
            }
            else
            {
                GoForTheBall(field);
            }
        }

        public override void ExecuteTurn(IField field)
        {
            bool ihavetheball = IHaveTheBall(field);
            if(ihavetheball)
            {
                if(Utils.ActivateWithProbability(0.6))
                    GoForward(field);
                else
                    PassTheBall(field);
            }
            else
            {
                ExecuteTurnWithoutBall(field);
            }
        }

        private void GoForAnOpponentPlayer()
        {
            throw new NotImplementedException();
        }

        private void GoForTheBall(IField field)
        {
            var pelota = field.GetBall();
            var lista = Utils.GetPositionsAtDistance(Position!, 1);
            lista = Utils.Filter(lista,field);
            lista.Sort((a, b) =>
            {
                if (a.GetDistance(pelota.Position!) < b.GetDistance(pelota.Position!))
                    return -1;
                if (a.GetDistance(pelota.Position!) > b.GetDistance(pelota.Position!))
                    return 1;
                return 0;
            });
            if (lista.Count > 0)
            {
                Position!.X = lista[0].X;
                Position.Y = lista[0].Y;
            }
        }

        private void PassTheBall(IField field)
        {
            throw new NotImplementedException();
        }

        private void GoForward(IField field)
        {
            throw new NotImplementedException();
        }

        private bool IHaveTheBall(IField field)
        {
            throw new NotImplementedException();
        }

        public override CharacterType GetCharacterType()
        {
            return CharacterType.DEFENDER;
        }
    }
}
