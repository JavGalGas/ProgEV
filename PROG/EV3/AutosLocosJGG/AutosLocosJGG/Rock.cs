using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class Rock : Obstacle
    {
        private double _weight;
        public Rock(string name) : base(name)
        {
            _weight = Utils.GetRandomBetween(10.0, 30.0);
        }

        public override void Simulate(IRace race)
        {
            race.VisitCars(car =>
            {
                if(car.Position >= position - 40 || car.Position <= position + 40)
                    if (Utils.ActivateWithProbability(0.1 + _weight))
                        car.SetCarPosition(car.Position - 25);
            });

            //List<RaceObject> cars = new List<RaceObject>();
            //for (int i = 0; i < race.GetObjectCount(); i++)
            //{
            //    if (race.GetObjectAt(i)!.Position >= position - 20 || race.GetObjectAt(i)!.Position <= position + 20)
            //    {
            //        cars.Add(race.GetObjectAt(i)!);
            //    }
            //}
            
            ////comprobar los objetos cerca de él y añadirlos a cars
            //if(ActivateWithProbability(random, 0.1 + _weight))
            //{
            //    foreach(Car car in cars)
            //    {
            //        car.SetPosition(car.Position-25);
            //    }
            //}
        }
    }
}
