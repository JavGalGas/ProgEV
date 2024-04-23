using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Defender : Player
    {
        private double _abilityToStealBall;
        public Defender(string name, Team team, Position position, double abilityToStealBall) : base(name, team, position)
        {
            _abilityToStealBall = abilityToStealBall;
            if (abilityToStealBall < 0.4)
                _abilityToStealBall = 0.4;

        }

        public Defender(string name, Team team, int x, int y) : this(name, team, new Position(x, y))
        {
        }

        private void ExecuteTurnWithoutBall(IField field)
        {
            bool tengolaPelota = IHaveTheBall(field);



        }

        public override void ExecuteTurn(IField field)
        {
            bool ihavetheball = IHaveTheBall(field);
            if(ihavetheball)
            {
                if(Utils.ActivateWithProbability(0.6))
                    Avanzar(field);
                else
                    PasarLaPelota(field);
            }
            else
            {
                var ball = field.GetBall();
                bool ballAtReach = Utils.IsBallAtReach(this, field);
                bool ballWithoutOwner = ball.HasBallPlayer == null;
                if (ballAtReach)
                {
                    if (ballWithoutOwner)
                    {
                        ball.HasBallPlayer = this;
                    }
                    else
                    {
                        
                        if (Utils.ActivateWithProbability(_abilityToStealBall) && ball!.HasBallPlayer!.Team != Team)
                        {
                            IrAPorAlguienDelEquipoContrario();
                        }
                        else
                        {
                            IrAPorLaPelota();
                        }
                    }
                }
            }
        }

        private void IrAPorLaPelota(IField field)
        {
            var pelota = field.GetBall();
            var lista = Utils.GetPositionsAtDistance(Position, 1, field);
            lista = Utils.Filter();
            lista.Sort((a, b) =>
            {
                if (a.GetDistance(pelota.Position) < b.GetDistance(pelota.Position))
                    return -1;
                if (a.GetDistance(pelota.Position) > b.GetDistance(pelota.Position))
                    return 1;
                return 0;
            });
            if (lista.Count > 0)
            {
                Position.X = lista[0].X;
                Position.Y = lista[0].Y;
            }
            

            if (pelota.Position.X > Position.X)
                Position.X++;
            if (pelota.Position.X < Position.X)
                Position.X--;
        }

        private void PasarLaPelota(IField field)
        {
            throw new NotImplementedException();
        }

        private void Avanzar(IField field)
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
