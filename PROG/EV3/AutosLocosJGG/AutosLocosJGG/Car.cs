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

        public Car(string name, double position, double finetunningValue) : base (name, position)
        {
            if (finetunningValue >= 1 && finetunningValue <= 3)
                finetunning = finetunningValue;
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
