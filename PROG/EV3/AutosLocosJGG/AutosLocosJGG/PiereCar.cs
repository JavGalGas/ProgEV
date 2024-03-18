using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class PiereCar : Car
    {
        private int _traps;
        public PiereCar(string name) : base(name)
        {
            driver = new Human();
            copilot = new Animal();
            _traps = (int)Utils.GetRandomBetween(10, 20);
        }

        public override void Simulate(IRace race)
        {
            if (disabledTurns > 0)
            {
                disabledTurns--;
                return;
            }
            SetCarPosition(Position + 18 + GetDriversVelocityExtra() + boost);
            if (Utils.ActivateWithProbability(0.5))
                SetTrap(race);
            boost += finetunning;
        }

        private void SetTrap(IRace race)
        {
            if(_traps < 0)
            {
                return;
            }
            double thresshold = Position;
            double savedPosition = 0.0;
            int index = 0;
            race.VisitCars(car =>
            {
                if (car.Position < thresshold && car.Position > savedPosition)
                {
                    index = race.IndexOf(car);
                    savedPosition = car.Position;
                }
            });
            if(Utils.ActivateWithProbability(0.3))
                race.GetObjectAt(index)!.Disable(1);
            else
            {
                copilot = null;
            }
            _traps--;
        }
    }
}
