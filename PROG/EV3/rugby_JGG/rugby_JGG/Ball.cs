using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Ball : GameObject
    {//comprobar su posicion en el random para que no coincida con un demento

        public Player? HasBallPlayer;

        public Ball(Position position) : base(position)
        {
        }

        public Position? GetPosition() => (HasBallPlayer != null) ? HasBallPlayer.Position : Position;
    }
}
