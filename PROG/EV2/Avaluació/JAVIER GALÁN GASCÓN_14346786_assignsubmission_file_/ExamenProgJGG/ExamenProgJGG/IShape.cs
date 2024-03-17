namespace Examen3
{
    public interface IShape
    {
        string Name { get; set; }
        Color Color { get; set; }
        bool HasArea { get; }
        double Area { get; }
        double Perimeter { get; }
        Point2D Center { get; }
        Rect2D Rect { get; }

        void Draw(ICanvas canvas);

    }
}
