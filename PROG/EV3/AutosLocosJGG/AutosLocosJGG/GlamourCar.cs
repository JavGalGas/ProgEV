using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class GlamourCar : Car
    {
        public GlamourCar(string name) : base(name)
        {
            driver = new Human();
        }

        public override void Simulate(IRace race)
        {
            if (disabledTurns > 0)
            {
                disabledTurns--;
                return;
            }
            SetCarPosition(Position + 20 + GetDriversVelocityExtra() + boost);
            boost += finetunning;
        }
    }
}
