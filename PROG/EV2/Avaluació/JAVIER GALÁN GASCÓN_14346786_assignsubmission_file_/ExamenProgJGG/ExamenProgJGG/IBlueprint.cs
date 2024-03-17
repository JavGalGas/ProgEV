namespace Examen3
{
    public delegate bool FilterDelegate(IShape shape);
    public interface IBlueprint
    {
        void AddShape(IShape shape);
        void RemoveShapeWhithName(string name);
        IShape GetShapeWithName(string name);
        List<IShape> GetShapes(FilterDelegate del);
        void Draw(ICanvas canvas);
    }
}
