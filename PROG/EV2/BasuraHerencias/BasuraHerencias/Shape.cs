using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasuraHerencias
{
    public abstract class Shape : IShape
    {
        protected Point2D _position = new Point2D();
        private string _name = "";
        private ShapeType _type;

        public Shape(ShapeType type)
        {
            _type = type;
        }

        public Shape(Point2D position, string name)
        {
            _position = position;
            _name = name;
        }

        string IShape.GetName()
        {
            return _name;
        }

        public Point2D GetPosition()
        {
            return _position;
        }
        public void SetPosition(Point2D point2D)
        {
            _position = point2D;
        }

        public void SetName(string name)
        {
            this._name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public abstract ShapeType GetShapeType();
        //{
        //    return this._type;
        //}

        public abstract double GetArea();


        public abstract bool HasArea();

    }
}
