namespace Examen3
{
    public class Blueprint : IBlueprint
    {
        private List<IShape> _shape = new List<IShape>();
        public IShape GetShapeWithName(string name)
        {
            if (name == null)
                throw new Exception("El nombre que se introdujo es nulo");
            for (int i = 0; i < _shape.Count - 1; i++)
            {
                IShape shape = _shape[i];
                if (shape.Name.Equals(name))
                    return shape;
            }
            // Javi: Bueno, yo devolvería un null
            throw new Exception("El nombre que se introdujo no fue encontrado");
        }

        public void RemoveShapeWhithName(string name)
        {
            if (name == null)
                throw new Exception("El nombre que se introdujo es nulo");
            for (int i = 0; i < _shape.Count - 1; i++)
            {
                IShape shape = _shape[i];
                if (shape.Name.Equals(name))
                    _shape.RemoveAt(i);
                // Javi: i--!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            }
        }
        public void AddShape(IShape shape)
        {
            if (shape == null)
                return;
            _shape.Add(shape);
        }

        public void Draw(ICanvas canvas)
        {
            if (canvas == null)
                return;
            for(int i = 0 ; i < _shape.Count -1; i++)
            {
                IShape shape = _shape[i];
                shape.Draw(canvas);
            }
        }

        public List<IShape> GetShapes(FilterDelegate del)
        {
            List<IShape> shapes = new List<IShape>();
            if (del == null)
                return shapes;
            for (int i = 0; i < _shape.Count - 1; i++)
            {
                IShape shape = _shape[i];
                bool comprobation = del(shape);
                if (comprobation)
                    shapes.Add(shape);
            }
            return shapes;
        }
    }
}
