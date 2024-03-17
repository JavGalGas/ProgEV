namespace Examen3
{
    internal class Program
    {
        // Javi: 
        // Ejercicio 1: 5
        // Ejercicio 2: 10
        // Ejercicio 3: 9
        // Ejercicio 4: 5
        // Ejercicio 5: 4
        // Ejercicio 6: 2
        // Ejercicio 7: 6 ..., no sé
        static void Main(string[] args)
        {
            var color = new Color()
            {
                R = 255, G = 255, B = 255, A = 255
            };
            var p = new Point2D()
            {
                X = 0,
                Y = 0,
            };
            var p2 = new Point2D()
            {
                X = 1,
                Y = 1,
            };
            var p3 = new Point2D()
                { X = 2, Y = 2 };
            var p4 = new Point2D() { X = 3, Y = 3 };
            var p5 = new Point2D() { X = 4, Y = 4 };
            Point2D[] p1= new Point2D[5];
            p1[0] = p;
            p1[1] = p2;
            p1[2] = p3;
            p1[3] = p4;
            p1[4] = p5;

            var n = Utils.GetArea(p1);
            


        }
    }
}