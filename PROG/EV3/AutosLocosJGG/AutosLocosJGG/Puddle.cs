using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class Puddle : Obstacle
    {
        public Puddle(string name) : base(name)
        { 
        }

        public override void Simulate(IRace race)
        {
            race.VisitCars(car =>
            {
                if (car.Position >= position - 20 || car.Position <= position + 20)
                    if (Utils.ActivateWithProbability(0.2))
                        car.Disable((int)Utils.GetRandomBetween(0,3));
            });
        }
    }
}
