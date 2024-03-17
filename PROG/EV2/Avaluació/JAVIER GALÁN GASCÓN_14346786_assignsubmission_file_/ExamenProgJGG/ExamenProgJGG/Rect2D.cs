using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class Rect2D
    {
        public double MinX, MinY, MaxX, MaxY;

        public double Area
        {
            get
            {
                return (MaxX - MinX) * (MaxY - MinY);
            }
        }// TODO:
        public Point2D Center
        {
            get
            {
                Point2D center = new Point2D();
                center.X = MaxX - MinX;
                center.Y = MaxY - MinY;
                return center;
            }
        }
        // TODO:
    }
}
