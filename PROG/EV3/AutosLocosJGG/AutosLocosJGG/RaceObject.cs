using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public enum ObjectType
    {
        OBSTACLE,
        CAR
    }
    public abstract class RaceObject
    {
        private string _name = "";
        protected double position;
        protected int disabledTurns;

        protected RaceObject(string name)
        {
            _name = name;
        }

        public abstract bool IsAlive { get; }
        public string Name {  get => _name; }
        public double Position { get => position; }

        public abstract ObjectType GetObjectType();
        public virtual void Disable(int turns)
        {
            if(disabledTurns < 0)
                return;
            disabledTurns += turns;
        }
        public virtual void Simulate(IRace race)
        {
            //ver como hacer bien esta función
        }

        public override bool Equals(object? obj)
        {
            if (this == obj)
                return true;
            if (obj is not RaceObject)
                return false;
            RaceObject s = (RaceObject)obj;
            return s.Name == Name;
        }

        // Sobrescribe el método GetHashCode para cumplir con las recomendaciones de diseño
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
