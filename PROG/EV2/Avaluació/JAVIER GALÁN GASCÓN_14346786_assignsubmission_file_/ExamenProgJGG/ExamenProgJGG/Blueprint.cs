using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class Blueprint : IBlueprint
    {
        public List<IShape> shapes = new List<IShape>();

        public void AddShape(IShape shape)
        {
            shapes.Add(shape);
        }

        public void Draw(ICanvas canvas)
        {
            throw new NotImplementedException();
        }

        public List<IShape> GetShapes(IBlueprint.FilterDelegate del)
        {
            throw new NotImplementedException();
        }

        public IShape? GetShapeWithName(string name)
        {
            for (int i = 0; i < shapes.Count; i++)
            {
                if (shapes[i].Name == name)
                    return shapes[i];
            }
            return null;
        }

        public void RemoveShapeWithName(string name)
        {
            foreach (IShape shape in shapes)
            {
                if(shape.Name == name)
                    shapes.Remove(shape);
            }
        }
    }
}
