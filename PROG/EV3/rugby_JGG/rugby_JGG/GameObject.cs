using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class GameObject
    {
        private Position _position;
        public Position position => _position;


        public GameObject(Position position)
        {
            _position = position;
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
