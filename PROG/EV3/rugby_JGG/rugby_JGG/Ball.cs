using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rugby_JGG
{
    public class Ball
    {//comprobar su posicion en el random para que no coincida con un dementor
        private int x, y;

        public int X => x;
        public int Y => y;

        public Ball() 
        {
            x = Utils.GetRandomBetween(MatchY,4);
            y = Utils.GetRandomBetween(0,4);
        }
    }
}
