using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public interface IBlueprint
    {
        public abstract void AddShape(IShape shape);

        public abstract int GetShapeCount();

        public void GetShapeAt(int index)
        {

        }
        public void RemoveShapeAt(int index)
        {

        }
        public abstract double GetArea();
        //{
        //    return 0;
        //}
    }
}
