using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class TroglodyteCar : Car
    {
        public TroglodyteCar(string name) : base(name)
        {
            driver = new Human();
            copilot = new Human();
        }

        public override void Simulate(IRace race)
        {
            if (disabledTurns > 0)
            {
                disabledTurns--;
                return;
            }
            SetPosition(Position + 10 + driver!.GetVelocityExtra() +copilot!.GetVelocityExtra()+ boost);
            if(Utils.ActivateWithProbability(0.3))
            {
                if (Utils.ActivateWithProbability(0.4))
                    SetPosition(Position + 20);
                if (Utils.ActivateWithProbability(0.2))
                    Disable(1);
            }
            boost += finetunning;
        }
    }
}
