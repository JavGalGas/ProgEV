using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public enum ShapeType
    {
        POLYLINE2D,
        RECT2D,
        POINTSHAPE2D,
        CIRCLE2D,
        POINT2D,
        SEGMENT2D
    }
    public interface IShape
    {

        string GetName();

        Point2D GetPosition();
        void SetPosition(Point2D point);
        abstract double GetArea();
        abstract bool HasArea();
        abstract ShapeType GetShapeType();

    }
}
