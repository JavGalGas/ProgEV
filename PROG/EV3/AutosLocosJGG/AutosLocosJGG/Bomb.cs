using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class Bomb : Obstacle
    {
        private bool hasNotExploded = true;
        private int timer;
        public Bomb(string name, int time) : base(name)
        {
            timer = time;
        }
        public override void Simulate(IRace race)
        {
            if (timer > 0)
            {
                timer--;
                return;
            }

            race.VisitCars(car =>
            { 
                if (car.Position >= position - 70 || car.Position <= position + 70)
                {
                    car.SetCarPosition(car.Position - Utils.GetRandomBetween(-50,50));
                    hasNotExploded = false;
                }           
            });
        }

        public override bool GetIfIsAlive()
        {
            return hasNotExploded;
        }
    }
}
