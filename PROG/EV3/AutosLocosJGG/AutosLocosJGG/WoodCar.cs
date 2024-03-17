using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class WoodCar : Car
    {
        public WoodCar(string name) : base(name)
        {
            driver = new Human();
            copilot = new Animal();
        }

        public override void Simulate(IRace race)
        {
            if (disabledTurns > 0 && Utils.ActivateWithProbability(0.6))
                disabledTurns = 0;
            if (disabledTurns > 0)
            {
                disabledTurns--;
                return;
            }
            SetPosition(Position + 15 + driver!.GetVelocityExtra() + copilot!.GetVelocityExtra() + boost);
            boost += finetunning;
        }
    }
}
