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
        private int _disabledTurns;

        protected RaceObject(string name, double position)
        {
            _name = name;
            this.position = position;
        }

        public abstract bool IsAlive { get; }
        public string Name {  get => _name; }
        public double Position { get => position; }

        public abstract ObjectType GetObjectType();
        public virtual void Disable(int turns)
        {
            _disabledTurns += turns;
            if (_disabledTurns > 0)
            {
                /*...*/
                _disabledTurns--;
            }
        }
        public virtual void Simulate(IRace race)
        {
            //ver como hacer bien esta función
        }

        public virtual bool ActivateWithProbability(Random random, double probability)
        {
            // Genera un número aleatorio entre 0 y 1
            double randomNumber = random.NextDouble();

            // Compara con la probabilidad deseada
            return randomNumber < probability;
        }
    }
}
