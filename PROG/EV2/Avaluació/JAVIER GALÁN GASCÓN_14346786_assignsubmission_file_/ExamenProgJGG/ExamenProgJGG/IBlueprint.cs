using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public interface IBlueprint
    {
        public delegate bool FilterDelegate(IShape shape);
        public void AddShape(IShape shape);
        public void RemoveShapeWithName(string name);
        public IShape? GetShapeWithName(string name);
        public List<IShape>? GetShapes(FilterDelegate del);
        public void Draw(ICanvas canvas);
    }
}
