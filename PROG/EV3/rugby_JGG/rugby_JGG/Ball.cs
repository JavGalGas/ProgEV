using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Ball
    {//comprobar su posicion en el random para que no coincida con un dementor
        private Position _position;

        public Ball(Position position)
        {
            _position = position;
        }

        public Position position => _position;

        public void SetPosition(Position position)
        {
            _position = position;/*cambiar*/
            if (_position == null)
            {
                _position = new Position()
                {
                    X = 0,
                    Y = 0
                };
            }     
        }
    }
}
