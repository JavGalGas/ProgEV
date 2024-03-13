namespace BasuraHerencias
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IShape rect = new Rect2D();

            if(rect is Rect2D)
            {
                Rect2D r = (Rect2D)rect;

            }
            rect.GetArea();
        }
    }
}