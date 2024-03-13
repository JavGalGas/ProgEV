using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public class Blueprint : IBlueprint
    {
        private List<IShape> _shapes;

        public Blueprint()
        {
            _shapes = new List<IShape>();
        }

        public void AddShape(IShape shape)
        {
            if(shape == null)
                return;
            _shapes.Add(shape);
        }

        public double GetArea() //area de todas las figuras : recorrer la lista
        {
            double result = 0; 
            if(GetShapeCount() <= 0)
                return -1;
            for(int i = 0; i< GetShapeCount(); i++)
            {
                result+= _shapes[i].GetArea();
            }
            return result;
        }

        public IShape? GetShapeAt(int index)
        {
            if(index >= 0 && index < GetShapeCount())
                return _shapes[index];
            return null;
        }

        public int GetShapeCount()
        {
            return _shapes.Count;
        }

        public void RemoveShapeAt(int index)
        {
            if (index >= 0 && index < GetShapeCount())
                _shapes.RemoveAt(index);
            return;
            
        }


        //lista de Shapes
    }
}
