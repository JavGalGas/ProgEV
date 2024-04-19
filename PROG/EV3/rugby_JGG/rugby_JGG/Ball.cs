using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Ball
    {//comprobar su posicion en el random para que no coincida con un dementor
        private int _x, _y;

        public int X => _x;
        public int Y => _y;

        public void SetPosition((int,int) position)
        {
            _x = position.Item1;
            _y = position.Item2;
        }
    }
}
