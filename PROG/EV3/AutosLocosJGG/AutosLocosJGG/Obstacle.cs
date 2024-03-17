using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class Obstacle : RaceObject
    {
        public Obstacle(string name) : base(name) 
        { 
        } 
        public override bool IsAlive => GetIfIsAlive();//buscar la forma de implementar bien la property

        public override ObjectType GetObjectType()
        {
            return ObjectType.OBSTACLE;
        }

        public virtual bool GetIfIsAlive()
        {
            return true;
        }

    }
}
