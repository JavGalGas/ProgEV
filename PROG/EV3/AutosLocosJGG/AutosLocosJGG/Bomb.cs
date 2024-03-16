using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class Bomb : Obstacle
    {
        private bool HasExploded = false;
        public Bomb(string name, double position) : base(name, position)
        {

        }
        public override void Simulate(IRace race)
        {
            throw new NotImplementedException();
        }

        public override bool GetIfIsAlive()
        {
            return HasExploded;
        }
    }
}
