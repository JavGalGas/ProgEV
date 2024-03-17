using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class Car : RaceObject
    {
        public override bool IsAlive => throw new NotImplementedException();
        protected double finetunning;
        protected double boost;

        protected Driver? driver;
        protected Driver? copilot;

        public Driver Driver { get => driver!; }
        public Driver? Copilot { get => copilot; }

        public Car(string name) : base (name)
        {
            finetunning = Utils.GetRandomBetween(1, 3);
        }

        public override ObjectType GetObjectType()
        {
            return ObjectType.CAR;
        }

        public void SetPosition(double newPosition)
        {
            if(newPosition < 0)
                return;
            position = newPosition;
        }
    }
}
